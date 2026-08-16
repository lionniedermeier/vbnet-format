using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// Prints a node from the source it was parsed from, without offering a single break opportunity.
/// This is what lets rules be authored one node kind at a time: everything without a rule still
/// comes out correct, and constructs that must never be split -- XML literals, interpolated strings,
/// directives -- are routed here on purpose.
/// </summary>
internal static class VerbatimFormatter
{
    /// <summary>
    /// Prints <paramref name="node"/> as it stands, comments included. A node always covers exactly
    /// its own extent -- the trivia on its outer tokens too -- so a rule that prints its children and
    /// its own tokens covers everything once and only once.
    /// </summary>
    public static Doc Format(SyntaxNode node, FormatContext context) => Doc.Concat(
        TriviaPrinter.Leading(node.GetFirstToken(), context),
        Body(node, context),
        TriviaPrinter.Trailing(node.GetLastToken(), context));

    private static Doc Body(SyntaxNode node, FormatContext context)
    {
        var lines = SplitLines(node.ToString());

        if (lines.Length == 1)
        {
            return Doc.Text(lines[0]);
        }

        // Joining continued lines back together is always legal VB, so a node that carries nothing
        // line-bound is reflowed onto one line -- which is what makes the fallback idempotent.
        if (CanCollapse(node))
        {
            return Doc.Text(Collapse(lines));
        }

        // Re-indenting means taking whitespace off the front of a line and putting the current
        // indent there instead. That is only sound while the whitespace is layout; where it is
        // content, the line has to stay in the column it was written at.
        if (OwnsItsColumns(node))
        {
            return Doc.Verbatim(lines, VerbatimMode.Anchored);
        }

        return Doc.Verbatim(Dedent(lines, BaseIndentWidth(node, context), context), VerbatimMode.Preserve);
    }

    /// <summary>
    /// Whether a line inside <paramref name="node"/> begins in the middle of an XML token. The
    /// whitespace at the start of such a line is a character of the document, not indentation --
    /// see <see cref="Xml.XmlWhitespace"/> for where XML draws that line.
    /// </summary>
    private static bool OwnsItsColumns(SyntaxNode node) => node.DescendantTokens().Any(token =>
        token.Text.Contains('\n')
        && token.Parent is XmlTextSyntax
            or XmlStringSyntax
            or XmlCDataSectionSyntax
            or XmlCommentSyntax
            or XmlProcessingInstructionSyntax);

    /// <summary>Prints <paramref name="text"/> with its original columns. For disabled <c>#If</c> text.</summary>
    public static Doc Raw(string text) => Doc.Verbatim(SplitLines(text), VerbatimMode.Raw);

    /// <summary>Splits on any of the three line endings, keeping empty lines.</summary>
    public static ImmutableArray<string> SplitLines(string text)
    {
        var lines = ImmutableArray.CreateBuilder<string>();
        var start = 0;

        for (var i = 0; i < text.Length; i++)
        {
            if (text[i] is not ('\r' or '\n'))
            {
                continue;
            }

            lines.Add(text[start..i]);

            if (text[i] == '\r' && i + 1 < text.Length && text[i + 1] == '\n')
            {
                i++;
            }

            start = i + 1;
        }

        lines.Add(text[start..]);
        return lines.DrainToImmutable();
    }

    /// <summary>
    /// Whether the node's line breaks carry no meaning. A statement, a lambda body, a comment, a
    /// directive, an XML literal and an interpolated string each do, so none of them qualifies.
    /// </summary>
    private static bool CanCollapse(SyntaxNode node)
    {
        if (node is not ExpressionSyntax)
        {
            return false;
        }

        foreach (var descendant in node.DescendantNodesAndSelf())
        {
            if (descendant is StatementSyntax
                or XmlNodeSyntax
                or InterpolatedStringExpressionSyntax
                or MultiLineLambdaExpressionSyntax)
            {
                return false;
            }
        }

        return !node.DescendantTrivia().Any(t => t.IsDirective
            || t.IsKind(SyntaxKind.CommentTrivia)
            || t.IsKind(SyntaxKind.DocumentationCommentTrivia)
            || t.IsKind(SyntaxKind.DisabledTextTrivia));
    }

    private static string Collapse(ImmutableArray<string> lines)
    {
        var parts = new List<string>(lines.Length);

        foreach (var line in lines)
        {
            var trimmed = line.Trim();

            // A trailing underscore preceded by whitespace is a line continuation, not an identifier.
            if (trimmed.EndsWith('_') && (trimmed.Length == 1 || char.IsWhiteSpace(trimmed[^2])))
            {
                trimmed = trimmed[..^1].TrimEnd();
            }

            if (trimmed.Length > 0)
            {
                parts.Add(trimmed);
            }
        }

        return string.Join(" ", parts);
    }

    /// <summary>
    /// The column the node's first line starts at, so that the lines below it can be re-indented
    /// relative to wherever the printer places the node now.
    /// </summary>
    private static int BaseIndentWidth(SyntaxNode node, FormatContext context)
    {
        var line = context.Text.Lines.GetLineFromPosition(node.SpanStart);
        var content = context.Text.ToString(line.Span);
        var width = 0;

        foreach (var c in content)
        {
            if (c is not (' ' or '\t'))
            {
                break;
            }

            width = TextWidth.Advance(width, c, context.Options.IndentSize);
        }

        return width;
    }

    /// <summary>
    /// Strips up to <paramref name="baseWidth"/> columns of leading whitespace from every line but
    /// the first, which starts wherever the node starts and carries no indentation of its own.
    /// </summary>
    private static ImmutableArray<string> Dedent(
        ImmutableArray<string> lines,
        int baseWidth,
        FormatContext context)
    {
        var dedented = ImmutableArray.CreateBuilder<string>(lines.Length);
        dedented.Add(lines[0]);

        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            var consumed = 0;
            var index = 0;

            while (index < line.Length && line[index] is ' ' or '\t' && consumed < baseWidth)
            {
                consumed = TextWidth.Advance(consumed, line[index], context.Options.IndentSize);
                index++;
            }

            dedented.Add(line[index..]);
        }

        return dedented.DrainToImmutable();
    }
}
