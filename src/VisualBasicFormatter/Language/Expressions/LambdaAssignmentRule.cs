using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

internal static class LambdaAssignmentRule
{
    public static Doc? Tail(
        SyntaxToken op,
        ExpressionSyntax? value,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        if (
            value is not LambdaExpressionSyntax lambda
            || !ContinuationPoints.IsImplicitAfter(op, context.Unbreakable)
            || context.MustPrintVerbatim(lambda)
        )
        {
            return null;
        }

        return Doc.Group(
            context.Token(op),
            Doc.Indent(context.BreakAfter(op), visitor.Format(lambda))
        );
    }
}
