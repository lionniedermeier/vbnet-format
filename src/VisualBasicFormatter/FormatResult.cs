using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace VisualBasicFormatter;

/// <summary>The result of a formatting run.</summary>
/// <param name="Text">The formatted source; on failure, the input unchanged.</param>
/// <param name="Changed">Whether <paramref name="Text"/> differs from the input.</param>
/// <param name="Diagnostics">Parse errors, or the reasons the run was abandoned.</param>
/// <remarks>
/// A line that ends up over the limit is not reported. <see cref="FormatterOptions.MaxLineLength"/>
/// is a target rather than a ceiling, so an overlong line is a decision the formatter took, not a
/// failure it needs to confess to.
/// </remarks>
public sealed record FormatResult(
    string Text,
    bool Changed,
    ImmutableArray<Diagnostic> Diagnostics)
{
    /// <summary>The source could not be processed and was returned unchanged.</summary>
    public bool HasErrors => !Diagnostics.IsDefaultOrEmpty;
}
