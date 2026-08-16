namespace VisualBasicFormatter.Printing;

/// <summary>
/// What the printer needs to know. Deliberately separate from <see cref="FormatterOptions"/> so that
/// <c>Printing</c> stays free of VB and of product decisions.
/// </summary>
internal sealed record PrintOptions
{
    /// <summary>Column limit a group tries to stay within.</summary>
    public int MaxLineLength { get; init; } = 120;

    /// <summary>
    /// How far past <see cref="MaxLineLength"/> a line may run before it is worth breaking. The
    /// limit is a target, not a ceiling: a group that overruns it by a few columns reads better on
    /// one line than split across several, so only a real overrun buys a break.
    /// </summary>
    public int OverflowTolerance { get; init; } = 10;

    /// <summary>The width every measurement is actually taken against.</summary>
    public int Limit => MaxLineLength + OverflowTolerance;

    /// <summary>Columns per indent level.</summary>
    public int IndentSize { get; init; } = 4;

    /// <summary>Indent with tabs instead of spaces.</summary>
    public bool UseTabs { get; init; }

    /// <summary>Line ending of the output.</summary>
    public string NewLine { get; init; } = "\r\n";
}
