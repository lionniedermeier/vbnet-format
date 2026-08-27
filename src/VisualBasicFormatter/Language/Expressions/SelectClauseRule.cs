using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

internal static class SelectClauseRule
{
    public static Doc Format(SelectClauseSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        if (StructuralFallback.MustPrintVerbatim(node))
        {
            return StructuralFallback.Format(node, visitor, context);
        }

        return Doc.Group(
            context.Token(node.SelectKeyword),
            Doc.Indent(
                context.BreakAfterQueryOperator(node.SelectKeyword),
                StructuralFallback.Run(node.ChildNodesAndTokens().Skip(1), visitor, context)));
    }
}
