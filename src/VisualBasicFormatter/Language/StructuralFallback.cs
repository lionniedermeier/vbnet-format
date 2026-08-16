using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using VisualBasicFormatter.Language.Declarations;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// What a node kind without a rule of its own does: print its children in order, keeping the spacing
/// the pre-pass settled on, and offer no break of its own.
/// </summary>
/// <remarks>
/// This is what makes the migration incremental. A rule authored for one node kind takes effect
/// everywhere that kind occurs, without a rule having to exist for any of its ancestors -- unlike a
/// whole-node verbatim fallback, which would swallow the subtree and hide the rule.
/// </remarks>
internal static class StructuralFallback
{
    /// <summary>Prints <paramref name="node"/> by walking into it.</summary>
    public static Doc Format(SyntaxNode node, VbDocVisitor visitor, FormatContext context)
    {
        // Taking the node apart would move a comment onto the wrong line, so keep it as it stands.
        if (MustPrintVerbatim(node))
        {
            return VerbatimFormatter.Format(node, context);
        }

        var children = node.ChildNodesAndTokens();
        var parts = ImmutableArray.CreateBuilder<Doc>();

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            parts.Add(child.IsNode
                ? visitor.Format(child.AsNode())
                : context.Token(child.AsToken()));

            if (i + 1 < children.Count)
            {
                var next = children[i + 1];

                // Whatever stood between the two -- a space, a line break, an underscore
                // continuation -- collapses; the breaks are re-decided from scratch. An attribute
                // list is the one boundary that ends its line rather than merely separating.
                parts.Add(AttributePlacementRule.Break(child, next, context)
                    ?? context.Gap(next.SpanStart > child.Span.End));
            }
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

    /// <summary>
    /// Whether a comment, a documentation comment or a directive sits above a token inside
    /// <paramref name="node"/>. Its own leading trivia does not count -- that one is printed above
    /// the node either way.
    /// </summary>
    public static bool MustPrintVerbatim(SyntaxNode node)
    {
        var first = node.GetFirstToken();

        foreach (var token in node.DescendantTokens())
        {
            if (token != first && token.LeadingTrivia.Any(IsContent))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsContent(SyntaxTrivia trivia) =>
        trivia.IsDirective
        || trivia.IsKind(SyntaxKind.CommentTrivia)
        || trivia.IsKind(SyntaxKind.DocumentationCommentTrivia)
        || trivia.IsKind(SyntaxKind.DisabledTextTrivia);
}
