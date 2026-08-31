using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace VisualBasicFormatter;

/// <summary>The result of a formatting run.</summary>
/// <param name="Text">The formatted source; on failure, the input unchanged.</param>
/// <param name="Changed">Whether <paramref name="Text"/> differs from the input.</param>
/// <param name="Diagnostics">Parse errors, or the reasons the run was abandoned.</param>
/// <remarks>
/// A line that ends up over the limit is not reported.
/// </remarks>
public sealed record FormatResult(
    string Text,
    bool Changed,
    ImmutableArray<Diagnostic> Diagnostics)
{
    /// <summary>The source could not be processed and was returned unchanged.</summary>
    public bool HasErrors => !Diagnostics.IsDefaultOrEmpty;
}
