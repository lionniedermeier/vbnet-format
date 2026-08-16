namespace VisualBasicFormatter.Printing;

/// <summary>How a <see cref="Doc"/> verbatim region reproduces the source text it was built from.</summary>
internal enum VerbatimMode
{
    /// <summary>One line, emitted at the current column. Nothing else is possible.</summary>
    Single,

    /// <summary>
    /// Keep the interior line breaks; re-indent every line after the first relative to the current
    /// indent. The lines are stored with their leading whitespace already reduced to that residual.
    /// </summary>
    Preserve,

    /// <summary>
    /// Keep the interior line breaks and the original columns, for a region that begins where the
    /// printer happens to be. Whitespace that is content rather than layout -- the interior of a
    /// multi-line XML text, where a leading space is a character of the document -- is measured from
    /// the left margin, so such a region cannot be moved sideways at all.
    /// </summary>
    Anchored,

    /// <summary>
    /// Keep the interior line breaks and the original columns, and give up the indent already
    /// written for the first line too. For disabled <c>#If</c> text, whose content need not even be
    /// VB and which owns its line outright.
    /// </summary>
    Raw,
}
