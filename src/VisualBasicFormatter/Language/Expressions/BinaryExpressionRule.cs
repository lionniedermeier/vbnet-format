using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

/// <summary>
/// A run of equally ranked binary operators, broken after every operator or after none. Mixing
/// ranks in one run would suggest a precedence the code does not have, so a run stops where the
/// operator changes.
/// </summary>
internal static class BinaryExpressionRule
{
    /// <summary>Whether <paramref name="node"/> starts a run rather than continuing one.</summary>
    public static bool IsRunHead(BinaryExpressionSyntax node) =>
        ContinuationPoints.IsBreakableOperator(node.OperatorToken)
        && !(node.Parent is BinaryExpressionSyntax parent
            && parent.Left == node
            && parent.OperatorToken.IsKind(node.OperatorToken.Kind()));

    /// <summary>
    /// Prints the run headed by <paramref name="node"/>: head, then operator and operand.
    /// </summary>
    /// <remarks>
    /// <paramref name="isNested"/> is whether this run is itself an operand of another run -- a
    /// higher-precedence chain feeding into a lower-precedence one, e.g. <c>AndAlso</c> inside
    /// <c>OrElse</c>. A nested run must not contribute its own indent on top of the outer one; see
    /// <see cref="VbDocBuilder.Run(ImmutableArray{Doc}, bool)"/>.
    /// </remarks>
    public static Doc Format(
        BinaryExpressionSyntax node, VbDocVisitor visitor, FormatContext context, bool isNested = false)
    {
        var operators = new List<SyntaxToken>();
        var operands = new List<ExpressionSyntax>();
        var current = node;

        while (true)
        {
            operators.Add(current.OperatorToken);
            operands.Add(current.Right);

            if (current.Left is BinaryExpressionSyntax left
                && left.OperatorToken.IsKind(node.OperatorToken.Kind()))
            {
                current = left;
                continue;
            }

            operands.Add(current.Left);
            break;
        }

        operators.Reverse();
        operands.Reverse();

        // Content and separator in turn: an operand carries the operator that follows it, and the
        // break that operator permits stands between the two.
        var items = ImmutableArray.CreateBuilder<Doc>();

        for (var i = 0; i < operands.Count; i++)
        {
            if (i >= operators.Count)
            {
                items.Add(FormatOperand(operands[i], visitor, context));
                continue;
            }

            items.Add(
                Doc.Concat(FormatOperand(operands[i], visitor, context), Doc.Space, context.Token(operators[i])));
            items.Add(context.BreakAfter(operators[i]));
        }

        return VbDocBuilder.Run(items.DrainToImmutable(), indent: !isNested);
    }

    /// <summary>
    /// Formats one operand. An operand that is itself the head of a differently ranked run is
    /// recursed into directly, marked as nested, instead of being handed to the generic visitor --
    /// going through <see cref="VbDocVisitor.VisitBinaryExpression"/> would produce a fresh,
    /// un-nested call and so a second, additive indent.
    /// </summary>
    private static Doc FormatOperand(ExpressionSyntax operand, VbDocVisitor visitor, FormatContext context) =>
        operand is BinaryExpressionSyntax binary && IsRunHead(binary)
            ? Format(binary, visitor, context, isNested: true)
            : visitor.Format(operand);
}
