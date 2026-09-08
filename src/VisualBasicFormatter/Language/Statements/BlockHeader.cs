using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language.Statements;

internal static class BlockHeader
{
    public static bool IsCondition(SyntaxNode node)
    {
        var current = node;

        while (current.Parent is UnaryExpressionSyntax unary && unary.Operand == current)
        {
            current = unary;
        }

        return current.Parent switch
        {
            IfStatementSyntax parent => parent.Condition == current,
            ElseIfStatementSyntax parent => parent.Condition == current,
            WhileStatementSyntax parent => parent.Condition == current,
            WhileOrUntilClauseSyntax parent => parent.Condition == current,
            _ => false,
        };
    }
}
