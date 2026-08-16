using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Statements;

/// <summary>
/// A run of statements, each on its own line. The container owns the separators; the statement owns
/// its own comments, so nothing is printed twice.
/// </summary>
internal static class StatementListRule
{
    /// <summary>Prints every node in <paramref name="nodes"/>, preceded by the break that leads to it.</summary>
    public static Doc Format(IEnumerable<SyntaxNode> nodes, VbDocVisitor visitor, FormatContext context)
    {
        var parts = ImmutableArray.CreateBuilder<Doc>();

        foreach (var node in nodes)
        {
            parts.Add(context.Separator(node));
            parts.Add(visitor.Format(node));
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

    /// <summary>Prints <paramref name="node"/> the same way, or nothing when it is absent.</summary>
    public static Doc Format(SyntaxNode? node, VbDocVisitor visitor, FormatContext context) =>
        node is null ? Doc.Nothing : Doc.Concat(context.Separator(node), visitor.Format(node));
}
