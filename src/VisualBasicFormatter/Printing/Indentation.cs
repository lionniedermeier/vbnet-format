namespace VisualBasicFormatter.Printing;

/// <summary>
/// The whitespace a line starts with, plus the column it reaches. Carried instead of a level count
/// because <see cref="Doc.Align(Doc)"/> pins an arbitrary column that no level can express.
/// </summary>
internal readonly record struct Indentation(string Text, int Width)
{
    /// <summary>No indentation.</summary>
    public static readonly Indentation Root = new(string.Empty, 0);

    /// <summary>Alignment to a fixed column. Always spaces -- a column is not expressible with tabs.</summary>
    public static Indentation At(int column) => new(new string(' ', column), column);

    /// <summary>One level deeper.</summary>
    public Indentation Increase(PrintOptions options) => options.UseTabs
        ? new Indentation(Text + '\t', TextWidth.Advance(Width, '\t', options.IndentSize))
        : new Indentation(Text + new string(' ', options.IndentSize), Width + options.IndentSize);
}
