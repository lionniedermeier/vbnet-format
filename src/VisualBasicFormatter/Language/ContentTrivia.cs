using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language;

internal sealed class ContentTrivia
{
    private static readonly ContentTrivia EmptyInstance = new([], []);

    private readonly int[] _positions;
    private readonly int[] _lambdaBodyStarts;

    private ContentTrivia(int[] positions, int[] lambdaBodyStarts)
    {
        _positions = positions;
        _lambdaBodyStarts = lambdaBodyStarts;
    }

    public bool Intersects(TextSpan span)
    {
        if (_positions.Length == 0)
        {
            return false;
        }

        var index = Array.BinarySearch(_positions, span.Start + 1);
        if (index < 0)
        {
            index = ~index;
        }

        for (; index < _positions.Length && _positions[index] < span.End; index++)
        {
            if (_lambdaBodyStarts[index] <= span.Start)
            {
                return true;
            }
        }

        return false;
    }

    public static ContentTrivia Build(SyntaxNode root)
    {
        var positions = new List<int>();
        var lambdaBodyStarts = new List<int>();

        foreach (var item in root.DescendantNodesAndTokensAndSelf())
        {
            if (!item.IsToken)
            {
                continue;
            }

            var token = item.AsToken();
            var hasOtherContent = false;
            var hasCommentContent = false;

            foreach (var trivia in token.LeadingTrivia)
            {
                if (trivia.IsDirective || trivia.IsKind(SyntaxKind.DisabledTextTrivia))
                {
                    hasOtherContent = true;
                }
                else if (
                    trivia.IsKind(SyntaxKind.CommentTrivia)
                    || trivia.IsKind(SyntaxKind.DocumentationCommentTrivia)
                )
                {
                    hasCommentContent = true;
                }
            }

            if (!hasOtherContent && !hasCommentContent)
            {
                continue;
            }

            positions.Add(token.SpanStart);
            lambdaBodyStarts.Add(hasOtherContent ? -1 : LambdaBodyStart(token));
        }

        return positions.Count == 0
            ? EmptyInstance
            : new ContentTrivia([.. positions], [.. lambdaBodyStarts]);
    }

    private static int LambdaBodyStart(SyntaxToken token)
    {
        if (token.Parent?.FirstAncestorOrSelf<MultiLineLambdaExpressionSyntax>() is not { } lambda)
        {
            return -1;
        }

        var bodyStart = lambda.SubOrFunctionHeader.Span.End;
        return token.SpanStart >= bodyStart ? bodyStart : -1;
    }
}
