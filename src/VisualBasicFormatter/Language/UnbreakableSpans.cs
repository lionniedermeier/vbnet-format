using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language;

internal sealed class UnbreakableSpans
{
    private static readonly UnbreakableSpans EmptyInstance = new([], []);

    private readonly int[] _positions;
    private readonly int[] _depths;

    private UnbreakableSpans(int[] positions, int[] depths)
    {
        _positions = positions;
        _depths = depths;
    }

    public bool Contains(int position)
    {
        if (_positions.Length == 0)
        {
            return false;
        }

        var index = Array.BinarySearch(_positions, position);
        if (index < 0)
        {
            index = ~index - 1;
        }
        else
        {
            while (index + 1 < _positions.Length && _positions[index + 1] == position)
            {
                index++;
            }
        }

        return index >= 0 && _depths[index] > 0;
    }

    public static (int[] ContentTriviaStarts, UnbreakableSpans Unbreakable) Build(SyntaxNode root)
    {
        var events = new List<(int Position, int Delta)>();
        var contentStarts = new List<int>();

        foreach (var item in root.DescendantNodesAndTokensAndSelf())
        {
            if (item.IsToken)
            {
                var token = item.AsToken();
                var recordedContent = false;

                foreach (var trivia in token.LeadingTrivia)
                {
                    if (trivia.IsDirective)
                    {
                        events.Add((trivia.SpanStart, 1));
                        events.Add((trivia.Span.End, -1));
                    }

                    if (!recordedContent && IsContentTrivia(trivia))
                    {
                        contentStarts.Add(token.SpanStart);
                        recordedContent = true;
                    }
                }

                continue;
            }

            var node = item.AsNode()!;

            if (node is XmlEmbeddedExpressionSyntax)
            {
                events.Add((node.SpanStart, -1));
                events.Add((node.Span.End, 1));
            }
            else if (
                node
                    is InterpolatedStringExpressionSyntax
                        or XmlNodeSyntax
                        or SingleLineIfStatementSyntax
                && IsRoot(node)
            )
            {
                events.Add((node.SpanStart, 1));
                events.Add((node.Span.End, -1));
            }
        }

        return ([.. contentStarts], BuildIndex(events));
    }

    private static bool IsContentTrivia(SyntaxTrivia trivia) =>
        trivia.IsDirective
        || trivia.IsKind(SyntaxKind.CommentTrivia)
        || trivia.IsKind(SyntaxKind.DocumentationCommentTrivia)
        || trivia.IsKind(SyntaxKind.DisabledTextTrivia);

    private static UnbreakableSpans BuildIndex(List<(int Position, int Delta)> events)
    {
        if (events.Count == 0)
        {
            return EmptyInstance;
        }

        events.Sort((a, b) => a.Position.CompareTo(b.Position));

        var positions = new int[events.Count];
        var depths = new int[events.Count];
        var running = 0;

        for (var i = 0; i < events.Count; i++)
        {
            running += events[i].Delta;
            positions[i] = events[i].Position;
            depths[i] = running;
        }

        return new UnbreakableSpans(positions, depths);
    }

    private static bool IsRoot(SyntaxNode node)
    {
        for (var ancestor = node.Parent; ancestor is not null; ancestor = ancestor.Parent)
        {
            if (ancestor is XmlEmbeddedExpressionSyntax)
            {
                return true;
            }

            if (
                ancestor
                is InterpolatedStringExpressionSyntax
                    or XmlNodeSyntax
                    or SingleLineIfStatementSyntax
            )
            {
                return false;
            }
        }

        return true;
    }
}
