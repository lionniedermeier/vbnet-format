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

internal enum FileStatus
{
    Cached,
    Error,
    Unchanged,
    Formatted,
    WouldChange,
}

internal sealed record FileOutcome(
    string File,
    FileStatus Status,
    long Millis,
    string? Source,
    FormatResult? Result
);

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
        catch (AggregateException ex)
            when (ex.Flatten()
                    .InnerExceptions.All(inner =>
                        inner is IOException or UnauthorizedAccessException or InvalidDataException
                    )
            )
        {
            foreach (
                var message in ex.Flatten()
                    .InnerExceptions.Select(inner => inner.Message)
                    .Distinct()
            )
            {
                Console.Error.WriteLine($"vbfmt: {message}");
            }

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

        var outcomes = files
            .AsParallel()
            .AsOrdered()
            .WithMergeOptions(ParallelMergeOptions.NotBuffered)
            .Select(file => ProcessFile(file, engine, mode, cache));

        foreach (var outcome in outcomes)
        {
            switch (outcome.Status)
            {
                case FileStatus.Cached:
                    unchanged++;
                    if (verbose)
                    {
                        output.WriteLine(
                            $"{DisplayPath(root, outcome.File)} {outcome.Millis}ms (cached)"
                        );
                    }

                    break;

                case FileStatus.Error:
                    Report(outcome.File, outcome.Result!);
                    exitCode = ExitError;
                    break;

                case FileStatus.Unchanged:
                    if (mode == RunMode.Format)
                    {
                        unchanged++;
                        if (verbose)
                        {
                            output.WriteLine(
                                $"{DisplayPath(root, outcome.File)} {outcome.Millis}ms (unchanged)"
                            );
                        }
                    }

                    break;

                case FileStatus.WouldChange:
                    if (mode == RunMode.Diff)
                    {
                        output.Write(
                            UnifiedDiff.Create(outcome.File, outcome.Source!, outcome.Result!.Text)
                        );
                    }
                    else
                    {
                        output.WriteLine($"{outcome.File}: would be reformatted.");
                    }

                    if (exitCode == ExitOk)
                    {
                        exitCode = ExitWouldChange;
                    }

                    break;

                case FileStatus.Formatted:
                    formatted++;
                    if (verbose)
                    {
                        output.WriteLine($"{DisplayPath(root, outcome.File)} {outcome.Millis}ms");
                    }

                    break;
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

    private static FileOutcome ProcessFile(
        string file,
        FormatterEngine engine,
        RunMode mode,
        FormatCache? cache
    )
    {
        var fileStart = Stopwatch.GetTimestamp();
        var source = File.ReadAllText(file);
        var options = cache is null ? null : engine.OptionsFor(file);
        var checksum = cache is null ? null : FormatCache.Checksum(source, options!);

        if (cache is not null && cache.IsUpToDate(file, checksum!))
        {
            return new FileOutcome(file, FileStatus.Cached, Millis(fileStart), source, null);
        }

        var result = engine.Format(file, source);

        if (result.HasErrors)
        {
            cache?.Forget(file);
            return new FileOutcome(file, FileStatus.Error, Millis(fileStart), source, result);
        }

        if (mode is RunMode.Check or RunMode.Diff)
        {
            return new FileOutcome(
                file,
                result.Changed ? FileStatus.WouldChange : FileStatus.Unchanged,
                Millis(fileStart),
                source,
                result
            );
        }

        if (result.Changed)
        {
            File.WriteAllText(file, result.Text);
            cache?.Record(file, FormatCache.Checksum(result.Text, options!));
            return new FileOutcome(file, FileStatus.Formatted, Millis(fileStart), source, result);
        }

        cache?.Record(file, checksum!);
        return new FileOutcome(file, FileStatus.Unchanged, Millis(fileStart), source, result);
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
