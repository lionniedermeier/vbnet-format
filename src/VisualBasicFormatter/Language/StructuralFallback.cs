using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using VisualBasicFormatter.Language.Declarations;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// What a node kind without a rule of its own does: print its children in order, spaced by
/// <see cref="Spacing"/>, and offer no break of its own.
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
        if (context.MustPrintVerbatim(node))
        {
            return VerbatimFormatter.Format(node, context);
        }

        var children = node.ChildNodesAndTokens();
        var count = children.Count;

        if (count == 0)
        {
            return Doc.Nothing;
        }

        // One doc per child, plus one gap between each pair. Empty parts (a no-space gap, an absent
        // optional child) are left out here so the concat never has to filter them.
        var parts = ImmutableArray.CreateBuilder<Doc>(2 * count - 1);

        for (var i = 0; i < count; i++)
        {
            var child = children[i];
            Add(parts, child.IsNode ? visitor.Format(child.AsNode()) : context.Token(child.AsToken()));

            if (i + 1 < count)
            {
                var next = children[i + 1];

                // Whatever stood between the two -- a space, a line break, an underscore
                // continuation -- is dropped and the spacing re-decided from the two tokens. An
                // attribute list is the one boundary that ends its line rather than merely separating.
                Add(parts, AttributePlacementRule.Break(child, next, context) ?? context.Gap(child, next));
            }
        }

        return parts.Count switch
        {
            0 => Doc.Nothing,
            1 => parts[0],
            _ => Doc.Concat(parts.DrainToImmutable()),
        };

        static void Add(ImmutableArray<Doc>.Builder parts, Doc part)
        {
            if (part is not DocNothing)
            {
                parts.Add(part);
            }
        }
    }

    /// <summary>A consecutive run of children, spaced the way <see cref="Format"/> spaces them.</summary>
    public static Doc Run(
        IEnumerable<SyntaxNodeOrToken> children,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        var parts = ImmutableArray.CreateBuilder<Doc>();
        SyntaxNodeOrToken? previous = null;

        foreach (var child in children)
        {
            if (previous is { } behind)
            {
                parts.Add(context.Gap(behind, child));
            }

            parts.Add(
                child.IsNode ? visitor.Format(child.AsNode()) : context.Token(child.AsToken())
            );
            previous = child;
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

}
