namespace VisualBasicFormatter.Printing;

/// <summary>Column arithmetic. A tab advances to the next multiple of the indent width.</summary>
internal static class TextWidth
{
    /// <summary>The column after writing <paramref name="c"/> at <paramref name="column"/>.</summary>
    public static int Advance(int column, char c, int indentSize)
    {
        if (c != '\t')
        {
            return column + 1;
        }

        var stop = indentSize > 0 ? indentSize : 1;
        return column + stop - (column % stop);
    }

    /// <summary>The column after writing <paramref name="text"/> at <paramref name="startColumn"/>.</summary>
    public static int Measure(string text, int startColumn, int indentSize)
    {
        var column = startColumn;
        foreach (var c in text)
        {
            column = Advance(column, c, indentSize);
        }

        return column;
    }
}
