using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace VisualBasicFormatter.Language.Module;

internal enum FileSection
{
    Options,
    Imports,
    Attributes,
    Declarations,
}

internal static class SectionTail
{
    public static int Length(SyntaxTriviaList trivia, FileSection previous)
    {
        var tail = 0;
        var depth = 0;
        var groupBelongs = true;

        for (var i = 0; i < trivia.Count; i++)
        {
            var current = trivia[i];

            if (
                current.IsKind(SyntaxKind.WhitespaceTrivia)
                || current.IsKind(SyntaxKind.EndOfLineTrivia)
            )
            {
                continue;
            }

            if (current.IsKind(SyntaxKind.DisabledTextTrivia))
            {
                if (!BelongsTo(current, previous))
                {
                    groupBelongs = false;
                }

                continue;
            }

            if (!current.IsDirective)
            {
                return tail;
            }

            var kind = current.Kind();

            if (kind is SyntaxKind.IfDirectiveTrivia or SyntaxKind.RegionDirectiveTrivia)
            {
                if (depth == 0)
                {
                    groupBelongs = true;
                }

                depth++;
                continue;
            }

            if (kind is SyntaxKind.ElseIfDirectiveTrivia or SyntaxKind.ElseDirectiveTrivia)
            {
                continue;
            }

            if (kind is SyntaxKind.EndIfDirectiveTrivia or SyntaxKind.EndRegionDirectiveTrivia)
            {
                if (depth == 0)
                {
                    tail = i + 1;
                    continue;
                }

                depth--;

                if (depth == 0)
                {
                    if (!groupBelongs)
                    {
                        return tail;
                    }

                    tail = i + 1;
                }

                continue;
            }

            if (depth == 0)
            {
                return tail;
            }
        }

        return tail;
    }

    private static bool BelongsTo(SyntaxTrivia disabledText, FileSection section)
    {
        foreach (var line in disabledText.ToString().Split('\r', '\n'))
        {
            var trimmed = line.Trim();

            if (trimmed.Length == 0)
            {
                continue;
            }

            if (!LineBelongsTo(trimmed, section))
            {
                return false;
            }
        }

        return true;
    }

    private static bool LineBelongsTo(string line, FileSection section) =>
        section switch
        {
            FileSection.Options => StartsWithWord(line, "Option"),
            FileSection.Imports => StartsWithWord(line, "Imports"),
            FileSection.Attributes => line.StartsWith('<'),
            _ => false,
        };

    private static bool StartsWithWord(string text, string word) =>
        text.Length >= word.Length
        && text.AsSpan(0, word.Length).Equals(word, StringComparison.OrdinalIgnoreCase)
        && (text.Length == word.Length || char.IsWhiteSpace(text[word.Length]));
}
