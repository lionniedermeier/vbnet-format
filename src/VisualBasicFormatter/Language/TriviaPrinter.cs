using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// Turns trivia into document parts. Roslyn keeps every comment in the tree, so -- unlike a
/// formatter over an AST that drops them -- there is no attachment pass: a comment is printed by
/// whoever prints the token it hangs on, and that happens exactly once.
/// </summary>
internal static class TriviaPrinter
{
    /// <summary>
    /// The comments, documentation comments and directives above <paramref name="token"/>, each
    /// closed by the line break that separates it from what follows. Blank lines <em>before</em> the
    /// first of them belong to the enclosing list and are reported by
    /// <see cref="BlankLinesBefore(SyntaxToken)"/> instead.
    /// </summary>
    public static Doc Leading(SyntaxToken token, FormatContext context)
    {
        var trivia = token.LeadingTrivia;
        var parts = ImmutableArray.CreateBuilder<Doc>();
        var blankLines = 0;
        var written = false;

        for (var i = 0; i < trivia.Count; i++)
        {
            var current = trivia[i];

            if (current.IsKind(SyntaxKind.EndOfLineTrivia))
            {
                if (IsBlankLine(trivia, i))
                {
                    blankLines++;
                }

                continue;
            }

            if (Content(current) is not { } content)
            {
                continue;
            }

            if (written)
            {
                parts.Add(blankLines > 0 ? Doc.EmptyLine : Doc.HardLine);
            }

            parts.Add(content);
            blankLines = 0;
            written = true;
        }

        if (written)
        {
            parts.Add(blankLines > 0 ? Doc.EmptyLine : Doc.HardLine);
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

    /// <summary>
    /// A comment behind <paramref name="token"/> on the same line. It is parked as a line suffix so
    /// that it stays on that line even when a break is inserted before it, and it forces the
    /// enclosing group to break so that no following code can end up inside the comment.
    /// </summary>
    public static Doc Trailing(SyntaxToken token, FormatContext context)
    {
        var parts = ImmutableArray.CreateBuilder<Doc>();

        foreach (var trivia in token.TrailingTrivia)
        {
            if (Content(trivia) is not { } content)
            {
                continue;
            }

            parts.Add(Doc.LineSuffix(Doc.Concat(Doc.Space, content)));
            parts.Add(Doc.ExpandParent);
        }

        return Doc.Concat(parts.DrainToImmutable());
    }

    /// <summary>How many blank lines the author left above <paramref name="token"/>.</summary>
    public static int BlankLinesBefore(SyntaxToken token)
    {
        var trivia = token.LeadingTrivia;
        var blankLines = 0;

        for (var i = 0; i < trivia.Count; i++)
        {
            if (trivia[i].IsKind(SyntaxKind.EndOfLineTrivia))
            {
                if (IsBlankLine(trivia, i))
                {
                    blankLines++;
                }

                continue;
            }

            // Whitespace is indentation; anything else already belongs to the leading comments.
            if (!trivia[i].IsKind(SyntaxKind.WhitespaceTrivia))
            {
                break;
            }
        }

        return blankLines;
    }

    /// <summary>
    /// An end of line that no content preceded on the same line. A directive and a run of disabled
    /// text carry their own line ending, so an end of line behind one starts an empty line just as
    /// an end of line behind an end of line does.
    /// </summary>
    private static bool IsBlankLine(SyntaxTriviaList trivia, int index) =>
        index == 0
        || trivia[index - 1].IsKind(SyntaxKind.WhitespaceTrivia)
        || trivia[index - 1].IsKind(SyntaxKind.EndOfLineTrivia)
        || trivia[index - 1].ToFullString().EndsWith('\n');

    /// <summary>
    /// What a trivium contributes, or <c>null</c> when the printer owns it: whitespace and line
    /// breaks are indentation, a colon separates statements the block rule puts on their own lines
    /// anyway, and an underscore continuation is re-decided from scratch.
    /// </summary>
    private static Doc? Content(SyntaxTrivia trivia)
    {
        if (trivia.IsKind(SyntaxKind.CommentTrivia))
        {
            return Doc.Text(trivia.ToString().TrimEnd());
        }

        if (trivia.IsKind(SyntaxKind.DocumentationCommentTrivia))
        {
            return DocumentationComment(trivia);
        }

        // A directive is line-bound, is reproduced as it stands, and sits at the left margin the
        // way every VB tool writes it -- so it is emitted raw rather than at the current indent.
        if (trivia.IsDirective)
        {
            return VerbatimFormatter.Raw(trivia.ToString().Trim());
        }

        if (trivia.IsKind(SyntaxKind.DisabledTextTrivia))
        {
            return VerbatimFormatter.Raw(trivia.ToString().TrimEnd('\r', '\n'));
        }

        return null;
    }

    /// <summary>
    /// A <c>'''</c> block, line by line and never reflowed. Only the indentation is dropped -- the
    /// spacing behind the exterior marker is the author's.
    /// </summary>
    private static Doc DocumentationComment(SyntaxTrivia trivia)
    {
        var lines = VerbatimFormatter.SplitLines(trivia.ToFullString())
            .Select(l => l.TrimStart().TrimEnd())
            .Where(l => l.Length > 0)
            .Select(Doc.Text);

        return Doc.Join(Doc.HardLine, lines);
    }
}
