using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

internal static class SignatureRule
{
    public static Doc Format(SyntaxNode node, VbDocVisitor visitor, FormatContext context)
    {
        if (context.MustPrintVerbatim(node))
        {
            return StructuralFallback.Format(node, visitor, context);
        }

        var children = node.ChildNodesAndTokens();
        ParameterListSyntax? parameterList = null;

        foreach (var child in children)
        {
            if (child.AsNode() is ParameterListSyntax candidate)
            {
                parameterList = candidate;
                break;
            }
        }

        if (parameterList is null || parameterList.Parameters.Count == 0)
        {
            return StructuralFallback.Format(node, visitor, context);
        }

        var count = children.Count;
        var start = 0;

        while (start < count && children[start].AsNode() is AttributeListSyntax)
        {
            start++;
        }

        using var prefix = new DocListBuilder(2 * start);

        for (var i = 0; i < start; i++)
        {
            var child = children[i];
            var next = children[i + 1];

            prefix.Add(visitor.Format(child.AsNode()));
            prefix.Add(
                AttributePlacementRule.Break(child, next, context) ?? context.Gap(child, next)
            );
        }

        using var parts = new DocListBuilder(2 * (count - start) - 1);

        for (var i = start; i < count; i++)
        {
            var child = children[i];

            parts.Add(
                child.AsNode() == parameterList
                    ? VbDocBuilder.Bracketed(
                        parameterList.OpenParenToken,
                        parameterList.Parameters,
                        parameterList.CloseParenToken,
                        ListLayout.Packed,
                        visitor,
                        context
                    )
                : child.IsNode ? visitor.Format(child.AsNode())
                : context.Token(child.AsToken())
            );

            if (i + 1 < count)
            {
                parts.Add(context.Gap(child, children[i + 1]));
            }
        }

        return Doc.Concat(prefix.ToDoc(), Doc.Group(parts.ToDoc()));
    }
}
