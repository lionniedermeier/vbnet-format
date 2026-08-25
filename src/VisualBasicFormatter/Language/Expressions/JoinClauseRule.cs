using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

/// <summary>
/// A join, broken between the collection it joins in and the condition it joins on.
/// </summary>
/// <remarks>
/// The clause is split on its children rather than on its named properties, which is what keeps one
/// rule total over both join kinds: <see cref="SyntaxNode.ChildNodesAndTokens"/> flattens the
/// separated lists, so the same loop carries a group join's <c>Group</c>, <c>Into</c> and aggregation
/// variables, and any <see cref="JoinClauseSyntax.AdditionalJoins"/>, without naming any of them.
/// </remarks>
internal static class JoinClauseRule
{
    /// <summary>Prints <paramref name="node"/> with its condition indented below its head.</summary>
    public static Doc Format(JoinClauseSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        var children = node.ChildNodesAndTokens();
        var on = IndexOfOn(children, node.OnKeyword);

        // Malformed source may have no On to split at, and a comment inside has nowhere to go once
        // the clause is taken apart. Either way the fallback prints it as it stands.
        if (on < 0 || StructuralFallback.MustPrintVerbatim(node))
        {
            return StructuralFallback.Format(node, visitor, context);
        }

        // The group is measured from the column the query aligned its clauses at, so a join that
        // fits there stays on one line and only a longer one breaks. The indent composes on top of
        // that same column.
        return Doc.Group(
            Run(children.Take(on), visitor, context),
            Doc.Indent(
                context.SpacedBreakBefore(node.OnKeyword),
                Run(children.Skip(on), visitor, context)));
    }

    /// <summary>A consecutive run of children, spaced the way the structural fallback spaces them.</summary>
    private static Doc Run(
        IEnumerable<SyntaxNodeOrToken> children,
        VbDocVisitor visitor,
        FormatContext context)
    {
        var parts = ImmutableArray.CreateBuilder<Doc>();
        SyntaxNodeOrToken? previous = null;

        foreach (var child in children)
        {
            if (previous is { } behind)
            {
                parts.Add(context.Gap(child.SpanStart > behind.Span.End));
            }

            parts.Add(child.IsNode ? visitor.Format(child.AsNode()) : context.Token(child.AsToken()));
            previous = child;
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

    private static int IndexOfOn(ChildSyntaxList children, SyntaxToken on)
    {
        for (var i = 0; i < children.Count; i++)
        {
            if (children[i].IsToken && children[i].AsToken() == on)
            {
                return i;
            }
        }

        return -1;
    }
}
