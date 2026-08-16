namespace VisualBasicFormatter.Printing;

/// <summary>What a <see cref="Doc"/> line renders as, depending on the print mode.</summary>
internal enum LineKind
{
    /// <summary>Nothing when flat, a line break when broken. The break after <c>(</c> or after a <c>.</c>.</summary>
    Soft,

    /// <summary>A space when flat, a line break when broken. The break after a binary operator.</summary>
    Space,

    /// <summary>Always a line break. Statement separation.</summary>
    Hard,

    /// <summary>Always a line break preceded by an empty line. A blank line the author wrote.</summary>
    Empty,
}
