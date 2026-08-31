using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

internal static class ConcatAssignmentRule
{
    public static Doc? Tail(
        SyntaxToken op,
        ExpressionSyntax? value,
        VbDocVisitor visitor,
        FormatContext context)
    {
        if (value is not BinaryExpressionSyntax binary
            || !binary.OperatorToken.IsKind(SyntaxKind.AmpersandToken)
            || !BinaryExpressionRule.IsRunHead(binary)
            || !ContinuationPoints.IsImplicitAfter(op)
            || StructuralFallback.MustPrintVerbatim(binary))
        {
            return null;
        }

        return Doc.Group(
            context.Token(op),
            Doc.Indent(
                context.BreakAfter(op),
                BinaryExpressionRule.Format(binary, visitor, context, isNested: true)));
    }
}
