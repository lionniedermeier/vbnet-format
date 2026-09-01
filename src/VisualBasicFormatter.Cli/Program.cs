using System.CommandLine;
using Microsoft.Extensions.FileSystemGlobbing;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal static class Program
{
    /// <summary>0 = all good, 1 = <c>--check</c> found differences, 2 = error.</summary>
    private const int ExitOk = 0;
    private const int ExitWouldChange = 1;
    private const int ExitError = 2;

    private const string ConfigFileName = ".vbnet-format.json";

    private const string IgnoreFileName = ".vbnet-formatignore";

    private static readonly string[] AlwaysExcluded =
        ["bin", "obj", "node_modules", ".git", ".svn", ".hg"];

    private static int Main(string[] args)
    {
        var paths = new Argument<string[]>("paths")
        {
            Description = "Files, directories or glob patterns. Directories are searched for **/*.vb.",
            Arity = ArgumentArity.ZeroOrMore,
        };

        var check = new Option<bool>("--check")
        {
            Description = "Write nothing; exit code 1 if any file would be reformatted.",
        };

        var diff = new Option<bool>("--diff")
        {
            Description = "Write nothing; print the changes as a unified diff.",
        };

        var stdin = new Option<bool>("--stdin")
        {
            Description = "Read source from standard input and write the formatted result to standard output.",
        };

        var write = new Option<bool>("--write", "-w")
        {
            Description = "Format the files in place. Without it the formatted source is written to standard output and the files are left untouched.",
        };

        var maxLineLength = new Option<int?>("--max-line-length")
        {
            Description = "The column width lines are wrapped at (default 120). A target, not a hard ceiling.",
        };

        var indentSize = new Option<int?>("--indent-size")
        {
            Description = "The number of characters per indentation level (default 4).",
        };

        var useTabs = new Option<bool>("--use-tabs")
        {
            Description = "Indent with tabs instead of spaces.",
        };

        var endOfLine = new Option<EndOfLine?>("--end-of-line")
        {
            Description = "Line ending of the output: Auto (default, follows the file), Lf or CrLf.",
        };

        var languageVersion = new Option<string?>("--language-version")
        {
            Description = "The VB language version the parser assumes, e.g. 16.9 or latest (default).",
        };

        var noOrganizeImports = new Option<bool>("--no-organize-imports")
        {
            Description = "Leave the Imports statements untouched.",
        };

        var config = new Option<FileInfo?>("--config")
        {
            Description = $"Path to a {ConfigFileName}.",
        };

        var ignorePath = new Option<string[]>("--ignore-path")
        {
            Description = $"Path to a file of ignore patterns. Repeatable; replaces .gitignore and {IgnoreFileName}.",
            Arity = ArgumentArity.ZeroOrMore,
        };

        var noRespectGitignore = new Option<bool>("--no-respect-gitignore")
        {
            Description = "Do not read .gitignore.",
        };

        var noIgnore = new Option<bool>("--no-ignore")
        {
            Description = "Read no ignore file at all.",
        };

        var force = new Option<bool>("--force")
        {
            Description = $"Overwrite an existing {ConfigFileName}.",
        };

        var init = new Command(
            "init",
            $"Write a {ConfigFileName} with the default options into the working directory.");
        init.Options.Add(force);
        init.SetAction(result =>
            Guarded(() => RunInit(Directory.GetCurrentDirectory(), result.GetValue(force))));

        var root = new RootCommand("vbnet-format - a formatter for VB.NET source.");
        root.Subcommands.Add(init);
        root.Arguments.Add(paths);
        Option[] all =
        [
            check, diff, stdin, write, maxLineLength, indentSize, useTabs, endOfLine, languageVersion,
            noOrganizeImports, config, ignorePath, noRespectGitignore, noIgnore,
        ];

        foreach (var option in all)
        {
            root.Options.Add(option);
        }

        root.SetAction(result => Guarded(() =>
        {
            if (result.GetValue(write)
                && (result.GetValue(check) || result.GetValue(diff) || result.GetValue(stdin)))
            {
                Console.Error.WriteLine(
                    "vbnet-format: --write cannot be combined with --check, --diff or --stdin.");
                return ExitError;
            }

            var options = BuildOptions(
                result.GetValue(config),
                result.GetValue(maxLineLength),
                result.GetValue(indentSize),
                result.GetValue(useTabs),
                result.GetValue(endOfLine),
                result.GetValue(languageVersion),
                result.GetValue(noOrganizeImports));

            return result.GetValue(stdin)
                ? RunStdin(options)
                : RunFiles(
                    result.GetValue(paths) ?? [],
                    DiscoverIgnores(
                        Directory.GetCurrentDirectory(),
                        result.GetValue(ignorePath) ?? [],
                        !result.GetValue(noRespectGitignore),
                        result.GetValue(noIgnore)),
                    options,
                    result.GetValue(write),
                    result.GetValue(check),
                    result.GetValue(diff),
                    Console.Out);
        }));

        return root.Parse(args).Invoke();
    }

    private static int Guarded(Func<int> action)
    {
        try
        {
            return action();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
        {
            Console.Error.WriteLine($"vbnet-format: {ex.Message}");
            return ExitError;
        }
    }

    internal static int RunInit(string directory, bool force)
    {
        var path = Path.Combine(directory, ConfigFileName);

        if (File.Exists(path) && !force)
        {
            Console.Error.WriteLine($"vbnet-format: {path} already exists. Pass --force to overwrite.");
            return ExitError;
        }

        ConfigFile.From(new FormatterOptions()).Save(path);
        Console.Out.WriteLine($"{path}: created.");
        return ExitOk;
    }

    private static FormatterOptions BuildOptions(
        FileInfo? configFile,
        int? maxLineLength,
        int? indentSize,
        bool useTabs,
        EndOfLine? endOfLine,
        string? languageVersion,
        bool noOrganizeImports)
    {
        var options = new FormatterOptions();

        var path = configFile?.FullName ?? DiscoverConfig();
        if (path is not null)
        {
            options = ConfigFile.Load(path).ApplyTo(options);
        }

        // An explicit switch beats the configuration file.
        if (maxLineLength is { } limit)
        {
            options = options with { MaxLineLength = limit };
        }

        if (indentSize is { } indent)
        {
            options = options with { IndentSize = indent };
        }

        if (useTabs)
        {
            options = options with { UseTabs = true };
        }

        if (endOfLine is { } lineEnding)
        {
            options = options with { EndOfLine = lineEnding };
        }

        if (languageVersion is not null)
        {
            options = options with { LanguageVersion = ConfigFile.ParseLanguageVersion(languageVersion) };
        }

        if (noOrganizeImports)
        {
            options = options with { OrganizeImports = false };
        }

        return options;
    }

    private static string? DiscoverConfig()
    {
        for (var dir = new DirectoryInfo(Directory.GetCurrentDirectory()); dir is not null; dir = dir.Parent)
        {
            var candidate = Path.Combine(dir.FullName, ConfigFileName);
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        return null;
    }

    internal static IgnoreSet DiscoverIgnores(
        string baseDirectory,
        string[] ignorePaths,
        bool respectGitignore,
        bool noIgnore)
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
        string[] candidates = respectGitignore ? [".gitignore", IgnoreFileName] : [IgnoreFileName];

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

    private static int RunStdin(FormatterOptions options)
    {
        var result = VbFormatter.Format(Console.In.ReadToEnd(), options);
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
        IgnoreSet ignores,
        FormatterOptions options,
        bool write,
        bool check,
        bool diff,
        TextWriter output)
    {
        var matched = Resolve(paths).ToList();
        var files = matched.Where(file => !ignores.IsIgnored(file)).ToList();

        if (files.Count == 0)
        {
            if (matched.Count > 0)
            {
                Console.Error.WriteLine("vbnet-format: all matching .vb files are ignored.");
                return ExitOk;
            }

            Console.Error.WriteLine("vbnet-format: no .vb files found.");
            return ExitError;
        }

        var exitCode = ExitOk;

        foreach (var file in files)
        {
            var source = File.ReadAllText(file);
            var result = VbFormatter.Format(source, options);

            if (result.HasErrors)
            {
                Report(file, result);
                exitCode = ExitError;
                continue;
            }

            if (!write && !check && !diff)
            {
                output.Write(result.Text);
                continue;
            }

            if (!result.Changed)
            {
                continue;
            }

            if (diff)
            {
                output.Write(UnifiedDiff.Create(file, source, result.Text));
            }
            else if (check)
            {
                output.WriteLine($"{file}: would be reformatted.");
            }
            else
            {
                File.WriteAllText(file, result.Text);
                output.WriteLine($"{file}: formatted.");
            }

            if ((check || diff) && exitCode == ExitOk)
            {
                exitCode = ExitWouldChange;
            }
        }

        return exitCode;
    }

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
