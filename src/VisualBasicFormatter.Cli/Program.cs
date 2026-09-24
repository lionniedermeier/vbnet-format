using System.CommandLine;
using System.Diagnostics;
using Microsoft.Extensions.FileSystemGlobbing;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal enum RunMode
{
    Format,
    Check,
    Diff,
}

internal static class Program
{
    internal const int ExitOk = 0;
    internal const int ExitWouldChange = 1;
    internal const int ExitError = 2;

    internal const string DefaultConfigFileName = ".vbfmtrc";

    internal static readonly string[] IgnoreFileNames =
    [
        ".vbnetformatignore",
        ".vbfmtignore",
        ".vbnet-formatignore",
        ".vbnet-format-ignore",
    ];

    private static readonly string[] AlwaysExcluded =
    [
        "bin",
        "obj",
        "node_modules",
        ".git",
        ".svn",
        ".hg",
    ];

    private static readonly string[] AlwaysExcludedFiles = ["**/*.Designer.vb"];

    private static int Main(string[] args)
    {
        var root = new RootCommand("vbfmt - a formatter for VB.NET source.");
        root.Subcommands.Add(CliCommands.CreateFormatCommand());
        root.Subcommands.Add(CliCommands.CreateCheckCommand());
        root.Subcommands.Add(CliCommands.CreateInitCommand());

        return root.Parse(args).Invoke();
    }

    internal static int Guarded(Func<int> action)
    {
        try
        {
            return action();
        }
        catch (Exception ex)
            when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
        {
            Console.Error.WriteLine($"vbfmt: {ex.Message}");
            return ExitError;
        }
    }

    internal static int RunInit(string directory, bool force)
    {
        var path = Path.Combine(directory, DefaultConfigFileName);

        if (File.Exists(path) && !force)
        {
            Console.Error.WriteLine($"vbfmt: {path} already exists. Pass --force to overwrite.");
            return ExitError;
        }

        ConfigFile.From(new FormatterOptions()).Save(path);
        Console.Out.WriteLine($"{path}: created.");
        return ExitOk;
    }

    internal static IgnoreSet DiscoverIgnores(
        string baseDirectory,
        string[] ignorePaths,
        bool respectGitignore,
        bool noIgnore
    )
    {
        if (noIgnore)
        {
            return IgnoreSet.Empty;
        }

        if (ignorePaths.Length > 0)
        {
            return new IgnoreSet([.. ignorePaths.Select(IgnoreFile.Load)]);
        }

        var files = new List<IgnoreFile>();
        string[] candidates = respectGitignore
            ? [".gitignore", .. IgnoreFileNames]
            : IgnoreFileNames;

        foreach (var candidate in candidates)
        {
            var path = Path.Combine(baseDirectory, candidate);
            if (File.Exists(path))
            {
                files.Add(IgnoreFile.Load(path));
            }
        }

        return new IgnoreSet(files);
    }

    internal static int RunStdin(FormatterEngine engine)
    {
        var result = engine.FormatStandardInput(Console.In.ReadToEnd());
        if (result.HasErrors)
        {
            Report("<stdin>", result);
            return ExitError;
        }

        Console.Out.Write(result.Text);
        return ExitOk;
    }

    internal static int RunFiles(
        string[] paths,
        string root,
        IgnoreSet ignores,
        FormatterEngine engine,
        RunMode mode,
        bool verbose,
        bool summary,
        TextWriter output,
        FormatCache? cache = null
    )
    {
        var matched = Resolve(paths).ToList();
        var files = matched.Where(file => !ignores.IsIgnored(file)).ToList();

        if (files.Count == 0)
        {
            if (matched.Count > 0)
            {
                Console.Error.WriteLine("vbfmt: all matching .vb files are ignored.");
                return ExitOk;
            }

            Console.Error.WriteLine("vbfmt: no .vb files found.");
            return ExitError;
        }

        var exitCode = ExitOk;
        var formatted = 0;
        var unchanged = 0;
        var runStart = Stopwatch.GetTimestamp();

        // TODO: parallelize this loop
        foreach (var file in files)
        {
            var fileStart = Stopwatch.GetTimestamp();
            var source = File.ReadAllText(file);
            var options = cache is null ? null : engine.OptionsFor(file);
            var checksum = cache is null ? null : FormatCache.Checksum(source, options!);

            if (cache is not null && cache.IsUpToDate(file, checksum!))
            {
                unchanged++;
                if (verbose)
                {
                    output.WriteLine($"{DisplayPath(root, file)} {Millis(fileStart)}ms (cached)");
                }

                continue;
            }

            var result = engine.Format(file, source);

            if (result.HasErrors)
            {
                Report(file, result);
                exitCode = ExitError;
                cache?.Forget(file);
                continue;
            }

            if (mode is RunMode.Check or RunMode.Diff)
            {
                if (!result.Changed)
                {
                    continue;
                }

                if (mode == RunMode.Diff)
                {
                    output.Write(UnifiedDiff.Create(file, source, result.Text));
                }
                else
                {
                    output.WriteLine($"{file}: would be reformatted.");
                }

                if (exitCode == ExitOk)
                {
                    exitCode = ExitWouldChange;
                }

                continue;
            }

            if (result.Changed)
            {
                File.WriteAllText(file, result.Text);
                formatted++;
                cache?.Record(file, FormatCache.Checksum(result.Text, options!));
                if (verbose)
                {
                    output.WriteLine($"{DisplayPath(root, file)} {Millis(fileStart)}ms");
                }
            }
            else
            {
                unchanged++;
                cache?.Record(file, checksum!);
                if (verbose)
                {
                    output.WriteLine(
                        $"{DisplayPath(root, file)} {Millis(fileStart)}ms (unchanged)"
                    );
                }
            }
        }

        cache?.Save();

        if (mode == RunMode.Format && summary && formatted + unchanged > 0)
        {
            output.WriteLine(
                $"{formatted} formatted, {unchanged} unchanged in {Millis(runStart)}ms"
            );
        }

        return exitCode;
    }

    private static long Millis(long start) =>
        (long)Math.Round(Stopwatch.GetElapsedTime(start).TotalMilliseconds);

    private static string DisplayPath(string root, string file) =>
        Path.GetRelativePath(root, file).Replace('\\', '/');

    internal static IEnumerable<string> Resolve(string[] paths)
    {
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var effective = paths.Length > 0 ? paths : ["."];

        foreach (var path in effective)
        {
            foreach (var file in ResolveOne(path))
            {
                if (seen.Add(file))
                {
                    yield return file;
                }
            }
        }
    }

    private static IEnumerable<string> ResolveOne(string path)
    {
        if (File.Exists(path))
        {
            return [Path.GetFullPath(path)];
        }

        var root = Directory.Exists(path) ? path : Directory.GetCurrentDirectory();
        var pattern = Directory.Exists(path) ? "**/*.vb" : path;

        var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
        matcher.AddInclude(pattern);

        foreach (var excluded in AlwaysExcluded)
        {
            matcher.AddExclude($"**/{excluded}/**");
        }

        foreach (var excluded in AlwaysExcludedFiles)
        {
            matcher.AddExclude(excluded);
        }

        return matcher.GetResultsInFullPath(root);
    }

    private static void Report(string file, FormatResult result)
    {
        foreach (var diagnostic in result.Diagnostics)
        {
            var line = diagnostic.Location.GetLineSpan().StartLinePosition.Line + 1;
            Console.Error.WriteLine($"{file}({line}): {diagnostic.GetMessage()}");
        }
    }
}
