using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

internal static class SignatureClauseRule
{
    public static Doc Format<T>(
        SyntaxNode node,
        SyntaxToken keyword,
        SeparatedSyntaxList<T> items,
        VbDocVisitor visitor,
        FormatContext context
    )
        where T : SyntaxNode
    {
        if (items.SeparatorCount == 0 || context.MustPrintVerbatim(node))
        {
            return StructuralFallback.Format(node, visitor, context);
        }

        for (var i = 0; i < items.SeparatorCount; i++)
        {
            if (!ContinuationPoints.IsImplicitAfter(items.GetSeparator(i), context.Unbreakable))
            {
                return StructuralFallback.Format(node, visitor, context);
            }
        }

        using var flatItems = new DocListBuilder(2 * items.Count - 1);
        using var brokenItems = new DocListBuilder(2 * items.Count - 1);

        for (var i = 0; i < items.Count; i++)
        {
            var element = visitor.Format(items[i]);

            if (i == items.SeparatorCount)
            {
                flatItems.Add(element);
                brokenItems.Add(element);
                continue;
            }

            var separator = items.GetSeparator(i);

            flatItems.Add(Doc.Concat(element, context.Token(separator), Doc.Space));
            brokenItems.Add(Doc.Concat(element, context.Token(separator)));
            brokenItems.Add(context.BreakAfter(separator));
        }

        return Doc.ConditionalGroup(
            Doc.Concat(context.Token(keyword), Doc.Space, flatItems.ToDoc()),
            Doc.Concat(
                context.Token(keyword),
                Doc.Space,
                Doc.Group(Doc.Indent(Doc.Indent(brokenItems.ToDoc())), shouldBreak: true)
            )
        );
    }
}
