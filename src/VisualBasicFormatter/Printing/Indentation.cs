namespace VisualBasicFormatter.Printing;

/// <summary>
/// The whitespace a line starts with, plus the column it reaches. Carried instead of a level count
/// because <see cref="Doc.Align(Doc)"/> pins an arbitrary column that no level can express. The
/// printer builds and caches the text; see <c>DocPrinter.Deeper</c>.
/// </summary>
internal readonly record struct Indentation(string Text, int Width)
{
    /// <summary>No indentation.</summary>
    public static readonly Indentation Root = new(string.Empty, 0);
}
