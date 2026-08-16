using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language.Expressions;

/// <summary>
/// Finds the dots an invocation chain may be broken after. VB continues implicitly behind a member
/// qualifier, so <c>Values.</c> at the end of a line needs no underscore -- which is why this
/// formatter breaks <em>after</em> the dot and never before it.
/// </summary>
internal static class MemberChainRule
{
    /// <summary>
    /// The dots to break at, in source order, or empty when <paramref name="node"/> does not head a
    /// chain worth breaking.
    /// </summary>
    public static ImmutableArray<SyntaxToken> BreakDots(InvocationExpressionSyntax node)
    {
        // Only the outermost call owns the chain; otherwise every link would offer it again.
        if (ContinuesUpwards(node))
        {
            return [];
        }

        var dots = ImmutableArray.CreateBuilder<SyntaxToken>();

        for (ExpressionSyntax? current = node; current is not null;)
        {
            switch (current)
            {
                // A missing Expression is the leading dot of a With block, of an initializer key or
                // of a conditional access -- the cases where VB does demand an underscore.
                case MemberAccessExpressionSyntax access when access.Expression is not null:
                    if (IsInvoked(access) && ContinuationPoints.IsImplicitAfter(access.OperatorToken))
                    {
                        dots.Add(access.OperatorToken);
                    }

                    current = access.Expression;
                    break;

                case InvocationExpressionSyntax invocation:
                    current = invocation.Expression;
                    break;

                default:
                    current = null;
                    break;
            }
        }

        // One dot is not a chain; a single call is better served by breaking its argument list.
        // Plain property hops are skipped above: splitting State.Gesellschaften.Values shortens the
        // line barely and reads badly.
        if (dots.Count < 2)
        {
            return [];
        }

        dots.Reverse();
        return dots.DrainToImmutable();
    }

    private static bool IsInvoked(MemberAccessExpressionSyntax access) =>
        access.Parent is InvocationExpressionSyntax invocation && invocation.Expression == access;

    private static bool ContinuesUpwards(InvocationExpressionSyntax node) => node.Parent switch
    {
        MemberAccessExpressionSyntax access => access.Expression == node,
        InvocationExpressionSyntax invocation => invocation.Expression == node,
        _ => false,
    };
}
