using Microsoft.CodeAnalysis.VisualBasic;

namespace VisualBasicFormatter;

/// <summary>The line ending of the output.</summary>
public enum EndOfLine
{
    /// <summary>Adopt the line ending the input file uses.</summary>
    Auto,

    /// <summary>Line feed.</summary>
    Lf,

    /// <summary>Carriage return and line feed.</summary>
    CrLf,
}

/// <summary>
/// Configuration for <see cref="VbFormatter"/>.
/// </summary>
/// <remarks>
/// There are six options, and there is meant to be no seventh: vbnet-format decides the layout
/// itself, and every one of these earns its place by affecting correctness, interoperability with
/// other tooling, or accessibility. See <c>docs/rationale.md</c> for the rule and what it removed.
/// </remarks>
public sealed record FormatterOptions
{
    /// <summary>The column width lines are wrapped at.</summary>
    public int MaxLineLength { get; init; } = 120;

    /// <summary>The number of characters per indentation level.</summary>
    public int IndentSize { get; init; } = 4;

    /// <summary>Indent with tabs instead of spaces.</summary>
    public bool UseTabs { get; init; }

    /// <summary>The line ending of the output.</summary>
    public EndOfLine EndOfLine { get; init; } = EndOfLine.Auto;

    /// <summary>
    /// The language version the parser assumes. A parser input rather than a style choice; VB 16.9 is
    /// the language's final version, so the latest is a stable default.
    /// </summary>
    public LanguageVersion LanguageVersion { get; init; } = LanguageVersion.Latest;

    /// <summary>
    /// Sort, deduplicate and group the <c>Imports</c> statements. The only transformation that touches
    /// tokens rather than whitespace, and it collides with the equivalent command in other tooling,
    /// which is why it can be turned off.
    /// </summary>
    public bool OrganizeImports { get; init; } = true;
}
