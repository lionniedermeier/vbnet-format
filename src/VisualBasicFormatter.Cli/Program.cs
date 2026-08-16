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
            Description = "Path to a .vbnet-format.json.",
        };

        var root = new RootCommand("vbnet-format - a formatter for VB.NET source.");
        root.Arguments.Add(paths);
        Option[] all =
        [
            check, diff, stdin, maxLineLength, indentSize, useTabs, endOfLine, languageVersion,
            noOrganizeImports, config,
        ];

        foreach (var option in all)
        {
            root.Options.Add(option);
        }

        root.SetAction(result =>
        {
            try
            {
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
                        options,
                        result.GetValue(check),
                        result.GetValue(diff));
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
            {
                Console.Error.WriteLine($"vbnet-format: {ex.Message}");
                return ExitError;
            }
        });

        return root.Parse(args).Invoke();
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
            var candidate = Path.Combine(dir.FullName, ".vbnet-format.json");
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        return null;
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

    private static int RunFiles(string[] paths, FormatterOptions options, bool check, bool diff)
    {
        var files = Resolve(paths).ToList();
        if (files.Count == 0)
        {
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

            if (!result.Changed)
            {
                continue;
            }

            if (diff)
            {
                Console.Out.Write(UnifiedDiff.Create(file, source, result.Text));
            }
            else if (check)
            {
                Console.Out.WriteLine($"{file}: would be reformatted.");
            }
            else
            {
                File.WriteAllText(file, result.Text);
                Console.Out.WriteLine($"{file}: formatted.");
            }

            if ((check || diff) && exitCode == ExitOk)
            {
                exitCode = ExitWouldChange;
            }
        }

        return exitCode;
    }

    private static IEnumerable<string> Resolve(string[] paths)
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
        matcher.AddExclude("**/bin/**");
        matcher.AddExclude("**/obj/**");

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
