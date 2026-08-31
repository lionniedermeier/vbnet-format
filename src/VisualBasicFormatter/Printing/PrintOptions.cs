namespace VisualBasicFormatter.Printing;

/// <summary>
/// What the printer needs to know. Deliberately separate from <see cref="FormatterOptions"/> so that
/// <c>Printing</c> stays free of VB and of product decisions.
/// </summary>
internal sealed record PrintOptions
{
    /// <summary>Column limit a group tries to stay within.</summary>
    public int MaxLineLength { get; init; } = 120;

    /// <summary>Columns per indent level.</summary>
    public int IndentSize { get; init; } = 4;

    /// <summary>Indent with tabs instead of spaces.</summary>
    public bool UseTabs { get; init; }

    /// <summary>Line ending of the output.</summary>
    public string NewLine { get; init; } = "\r\n";
}
