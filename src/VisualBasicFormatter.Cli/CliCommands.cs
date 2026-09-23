using System.CommandLine;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal static class CliCommands
{
    public static Command CreateFormatCommand()
    {
        var paths = CreatePathsArgument();
        var shared = new SharedOptions();

        var stdin = new Option<bool>("--stdin")
        {
            Description =
                "Read source from standard input and write the formatted result to standard output.",
        };

        var verbose = new Option<bool>("--verbose", "-v")
        {
            Description = "Print one line per formatted file with the time it took.",
        };

        var summary = new Option<bool>("--summary")
        {
            Description = "Print how many files were formatted and how long the run took.",
        };

        var command = new Command("format", "Format files in place.");
        command.Arguments.Add(paths);
        command.Options.Add(stdin);
        command.Options.Add(verbose);
        command.Options.Add(summary);
        shared.AddTo(command);

        command.SetAction(result =>
            Program.Guarded(() =>
            {
                var engine = shared.CreateEngine(result);

                return result.GetValue(stdin)
                    ? Program.RunStdin(engine)
                    : Program.RunFiles(
                        result.GetValue(paths) ?? [],
                        Directory.GetCurrentDirectory(),
                        shared.DiscoverIgnores(result, Directory.GetCurrentDirectory()),
                        engine,
                        RunMode.Format,
                        result.GetValue(verbose),
                        result.GetValue(summary),
                        Console.Out
                    );
            })
        );

        return command;
    }

    public static Command CreateCheckCommand()
    {
        var paths = CreatePathsArgument();
        var shared = new SharedOptions();

        var diff = new Option<bool>("--diff")
        {
            Description = "Print the changes as a unified diff instead of a file list.",
        };

        var command = new Command("check", "Report files that would be reformatted.");
        command.Arguments.Add(paths);
        command.Options.Add(diff);
        shared.AddTo(command);

        command.SetAction(result =>
            Program.Guarded(() =>
            {
                var engine = shared.CreateEngine(result);

                return Program.RunFiles(
                    result.GetValue(paths) ?? [],
                    Directory.GetCurrentDirectory(),
                    shared.DiscoverIgnores(result, Directory.GetCurrentDirectory()),
                    engine,
                    result.GetValue(diff) ? RunMode.Diff : RunMode.Check,
                    verbose: false,
                    summary: false,
                    Console.Out
                );
            })
        );

        return command;
    }

    public static Command CreateInitCommand()
    {
        var force = new Option<bool>("--force")
        {
            Description = $"Overwrite an existing {Program.DefaultConfigFileName}.",
        };

        var command = new Command(
            "init",
            $"Write a {Program.DefaultConfigFileName} with the default options into the working directory."
        );
        command.Options.Add(force);
        command.SetAction(result =>
            Program.Guarded(() =>
                Program.RunInit(Directory.GetCurrentDirectory(), result.GetValue(force))
            )
        );

        return command;
    }

    private static Argument<string[]> CreatePathsArgument() =>
        new("paths")
        {
            Description =
                "Files, directories or glob patterns. Directories are searched for **/*.vb, skipping generated *.Designer.vb files.",
            Arity = ArgumentArity.ZeroOrMore,
        };

    private sealed class SharedOptions
    {
        private readonly Option<int?> _printWidth = new("--print-width")
        {
            Description =
                "The column width lines are wrapped at (default 120). A target, not a hard ceiling.",
        };

        private readonly Option<int?> _indentSize = new("--indent-size")
        {
            Description = "The number of characters per indentation level (default 4).",
        };

        private readonly Option<bool?> _useTabs = new("--use-tabs")
        {
            Description =
                "Indent with tabs instead of spaces. Pass false to force spaces even when the config file sets tabs.",
        };

        private readonly Option<EndOfLine?> _endOfLine = new("--end-of-line")
        {
            Description =
                "Line ending of the output: Auto (default, follows the file), Lf or CrLf.",
        };

        private readonly Option<string?> _languageVersion = new("--language-version")
        {
            Description =
                "The VB language version the parser assumes, e.g. 16.9 or latest (default).",
        };

        private readonly Option<bool> _noOrganizeImports = new("--no-organize-imports")
        {
            Description = "Leave the Imports statements untouched.",
        };

        private readonly Option<FileInfo?> _config = new("--config")
        {
            Description =
                $"Path to a config file. Without it, {string.Join(", ", ConfigLocator.FileNames)} are searched for, walking up from each file's own directory to the nearest repository root.",
        };

        private readonly Option<string[]> _ignorePath = new("--ignore-path")
        {
            Description =
                $"Path to a file of ignore patterns. Repeatable; replaces .gitignore and {string.Join("/", Program.IgnoreFileNames)}.",
            Arity = ArgumentArity.ZeroOrMore,
        };

        private readonly Option<bool> _noRespectGitignore = new("--no-respect-gitignore")
        {
            Description = "Do not read .gitignore.",
        };

        private readonly Option<bool> _noIgnore = new("--no-ignore")
        {
            Description = "Read no ignore file at all.",
        };

        public void AddTo(Command command)
        {
            command.Options.Add(_printWidth);
            command.Options.Add(_indentSize);
            command.Options.Add(_useTabs);
            command.Options.Add(_endOfLine);
            command.Options.Add(_languageVersion);
            command.Options.Add(_noOrganizeImports);
            command.Options.Add(_config);
            command.Options.Add(_ignorePath);
            command.Options.Add(_noRespectGitignore);
            command.Options.Add(_noIgnore);
        }

        public FormatterEngine CreateEngine(ParseResult result)
        {
            var overrides = new OptionOverrides
            {
                PrintWidth = result.GetValue(_printWidth),
                IndentSize = result.GetValue(_indentSize),
                UseTabs = result.GetValue(_useTabs),
                EndOfLine = result.GetValue(_endOfLine),
                LanguageVersion = result.GetValue(_languageVersion),
                OrganizeImports = result.GetValue(_noOrganizeImports) ? false : null,
            };

            return new FormatterEngine(overrides, result.GetValue(_config)?.FullName);
        }

        public IgnoreSet DiscoverIgnores(ParseResult result, string baseDirectory) =>
            Program.DiscoverIgnores(
                baseDirectory,
                result.GetValue(_ignorePath) ?? [],
                !result.GetValue(_noRespectGitignore),
                result.GetValue(_noIgnore)
            );
    }
}
