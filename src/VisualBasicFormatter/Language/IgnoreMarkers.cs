using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace VisualBasicFormatter.Language;

internal sealed class IgnoreMarkers
{
    private static readonly IgnoreMarkers EmptyInstance = new(null);

    private readonly HashSet<int>? _starts;

    private IgnoreMarkers(HashSet<int>? starts) => _starts = starts;

    public bool IsIgnored(SyntaxNode node) =>
        _starts is not null && _starts.Contains(node.SpanStart);

    public static IgnoreMarkers Build(SyntaxNode root)
    {
        HashSet<int>? starts = null;

        foreach (var token in root.DescendantTokens())
        {
            if (MarkerIndex(token.LeadingTrivia) < 0)
            {
                continue;
            }

            (starts ??= []).Add(token.SpanStart);
        }

        return starts is null ? EmptyInstance : new IgnoreMarkers(starts);
    }

    public static int MarkerIndex(SyntaxTriviaList trivia)
    {
        for (var i = trivia.Count - 1; i >= 0; i--)
        {
            if (trivia[i].IsKind(SyntaxKind.CommentTrivia) && IsMarker(trivia[i].ToString()))
            {
                return i;
            }
        }

        return -1;
    }

    private static bool IsMarker(string text) =>
        StripPrefix(text.TrimStart())
            .Trim()
            .Equals("vbfmt-ignore", StringComparison.OrdinalIgnoreCase);

    private static string StripPrefix(string text)
    {
        if (
            text.Length >= 3
            && text[..3].Equals("REM", StringComparison.OrdinalIgnoreCase)
            && (text.Length == 3 || char.IsWhiteSpace(text[3]))
        )
        {
            return text[3..];
        }

        return text.TrimStart('\'', '‘', '’');
    }
}
