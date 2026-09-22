using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal sealed record OptionOverrides
{
    public int? PrintWidth { get; init; }

    public int? IndentSize { get; init; }

    public bool? UseTabs { get; init; }

    public EndOfLine? EndOfLine { get; init; }

    public string? LanguageVersion { get; init; }

    public bool? OrganizeImports { get; init; }

    public FormatterOptions ApplyTo(FormatterOptions options) =>
        options with
        {
            PrintWidth = PrintWidth ?? options.PrintWidth,
            IndentSize = IndentSize ?? options.IndentSize,
            UseTabs = UseTabs ?? options.UseTabs,
            EndOfLine = EndOfLine ?? options.EndOfLine,
            LanguageVersion = LanguageVersion is null
                ? options.LanguageVersion
                : ConfigFile.ParseLanguageVersion(LanguageVersion),
            OrganizeImports = OrganizeImports ?? options.OrganizeImports,
        };
}
