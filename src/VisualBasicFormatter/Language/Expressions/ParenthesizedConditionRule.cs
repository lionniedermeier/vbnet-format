using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Statements;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

internal static class ParenthesizedConditionRule
{
    public static Doc? Format(
        ParenthesizedExpressionSyntax node,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        if (!BlockHeader.IsHeaderExpression(node) || context.MustPrintVerbatim(node))
        {
            return null;
        }

        if (CarriesItsOwnCloser(node.Expression))
        {
            return null;
        }

        var body = visitor.Format(node.Expression);

        if (Doc.ForceBreak(body) is not { } broken)
        {
            return null;
        }

        return Doc.Group(
            context.Token(node.OpenParenToken),
            Doc.Conditional(broken, body),
            context.SoftBreakBefore(node.CloseParenToken),
            context.Token(node.CloseParenToken)
        );
    }

    private static bool CarriesItsOwnCloser(ExpressionSyntax expression) =>
        Unwrap(expression) switch
        {
            InvocationExpressionSyntax invocation => invocation.ArgumentList
                is { Arguments.Count: > 0 },
            ObjectCreationExpressionSyntax creation => creation.Initializer is not null
                || creation.ArgumentList is { Arguments.Count: > 0 },
            ArrayCreationExpressionSyntax
            or AnonymousObjectCreationExpressionSyntax
            or CollectionInitializerSyntax => true,
            _ => false,
        };

    private static ExpressionSyntax Unwrap(ExpressionSyntax expression) =>
        expression is UnaryExpressionSyntax unary ? Unwrap(unary.Operand) : expression;
}
