using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// What every formatting rule needs: the options, the line ending, and a couple of read-only queries
/// over the tree -- never a place to copy the author's formatting decisions from.
/// </summary>
internal sealed class FormatContext
{
    private readonly Lazy<SourceText> _text;

    // Ascending start offsets of the tokens whose leading trivia carries a comment, a documentation
    // comment or a directive. Built once; MustPrintVerbatim binary-searches it.
    private readonly int[] _contentTriviaStarts;

    public FormatContext(FormatterOptions options, SyntaxNode root, string newLine)
    {
        Options = options;
        NewLine = newLine;

        _text = new Lazy<SourceText>(() => root.SyntaxTree.GetText());
        (_contentTriviaStarts, Unbreakable) = UnbreakableSpans.Build(root);

        PrintOptions = new PrintOptions
        {
            MaxLineLength = options.MaxLineLength,
            IndentSize = options.IndentSize,
            UseTabs = options.UseTabs,
            NewLine = newLine,
        };
    }

    /// <summary>The user's configuration.</summary>
    public FormatterOptions Options { get; }

    /// <summary>
    /// The source text the tree came from. Materialised on first use -- after the imports have been
    /// reorganised the tree is detached, and asking for its text rebuilds the whole file.
    /// </summary>
    public SourceText Text => _text.Value;

    /// <summary>Line ending of the output.</summary>
    public string NewLine { get; }

    /// <summary>The subset of <see cref="Options"/> the printer cares about.</summary>
    public PrintOptions PrintOptions { get; }

    public UnbreakableSpans Unbreakable { get; }

    /// <summary>
    /// A token with the comments that hang on it. The whitespace that separated it from its
    /// neighbours is deliberately not emitted: spacing is the rule's decision, not the input's.
    /// </summary>
    public Doc Token(SyntaxToken token)
    {
        var text = TokenText(token);

        var leading = token.HasLeadingTrivia ? TriviaPrinter.Leading(token, this) : Doc.Nothing;
        var trailing = token.HasTrailingTrivia ? TriviaPrinter.Trailing(token, this) : Doc.Nothing;

        // Whitespace-only trivia -- an indent -- prints nothing, so most tokens land here.
        if (leading is DocNothing && trailing is DocNothing)
        {
            return text;
        }

        return Doc.Concat(leading, text, trailing);
    }

    // Keywords and punctuation are a closed set with a fixed spelling, so their doc node is built
    // once and shared. Identifiers and literals carry their own text and fall through.
    private static readonly Doc?[] InternedText = BuildInternedText();

    private static Doc TokenText(SyntaxToken token)
    {
        var kind = (int)token.Kind();

        if (
            (uint)kind < (uint)InternedText.Length
            && InternedText[kind] is { } interned
            && token.Text == SyntaxFacts.GetText(token.Kind())
        )
        {
            return interned;
        }

        return Doc.Text(token.Text);
    }

    private static Doc?[] BuildInternedText()
    {
        var kinds = Enum.GetValues<SyntaxKind>();
        var max = 0;
        foreach (var kind in kinds)
        {
            max = Math.Max(max, (int)kind);
        }

        var table = new Doc?[max + 1];
        foreach (var kind in kinds)
        {
            var text = SyntaxFacts.GetText(kind);
            if (text.Length > 0)
            {
                table[(int)kind] = Doc.Text(text);
            }
        }

        return table;
    }

    /// <summary>
    /// A break the language permits behind <paramref name="token"/>, rendered as a space while the
    /// group stays flat. This is the only way an expression rule can obtain a break, which is what
    /// keeps the printer from proposing one where VB forbids it.
    /// </summary>
    public Doc BreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token, Unbreakable) ? Doc.Line : Doc.Nothing;

    /// <summary>The same, rendered as nothing while the group stays flat: behind <c>(</c> or a dot.</summary>
    public Doc SoftBreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token, Unbreakable) ? Doc.SoftLine : Doc.Nothing;

    public bool EndsItsLine(SyntaxToken token)
    {
        foreach (var trivia in token.TrailingTrivia)
        {
            if (trivia.IsKind(SyntaxKind.EndOfLineTrivia))
            {
                return true;
            }
        }

        var next = token.GetNextToken();
        if (next == default)
        {
            return false;
        }

        foreach (var trivia in next.LeadingTrivia)
        {
            if (trivia.IsKind(SyntaxKind.EndOfLineTrivia))
            {
                return true;
            }

            if (!trivia.IsKind(SyntaxKind.WhitespaceTrivia))
            {
                break;
            }
        }

        return false;
    }

    /// <summary>
    /// Whether a comment, a documentation comment or a directive sits above a token inside
    /// <paramref name="node"/> -- its own leading trivia excluded, since that is printed above the
    /// node either way. Such a node is reproduced verbatim rather than taken apart, so that the
    /// comment does not move onto the wrong line.
    /// </summary>
    public bool MustPrintVerbatim(SyntaxNode node)
    {
        var span = node.Span;

        var index = Array.BinarySearch(_contentTriviaStarts, span.Start + 1);
        if (index < 0)
        {
            index = ~index;
        }

        return index < _contentTriviaStarts.Length && _contentTriviaStarts[index] < span.End;
    }

    public Doc HardBreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token, Unbreakable) ? Doc.HardLine : Doc.Space;

    /// <summary>
    /// A break the language permits in front of <paramref name="token"/>: a query clause head, or a
    /// closing bracket. Everywhere else the break belongs behind the token it follows.
    /// </summary>
    public Doc BreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token, Unbreakable) ? Doc.Line : Doc.Nothing;

    /// <summary>
    /// The same, for a place where the two tokens must stay apart even when the break is refused:
    /// two keywords that would otherwise run together into a single word. Every other caller may
    /// take <see cref="Doc.Nothing"/> for an answer, because a refused break there only costs a
    /// layout -- here it would cost the code its meaning.
    /// </summary>
    public Doc SpacedBreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token, Unbreakable) ? Doc.Line : Doc.Space;

    /// <summary>The same, rendered as nothing while the group stays flat: in front of a closing bracket.</summary>
    public Doc SoftBreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token, Unbreakable) ? Doc.SoftLine : Doc.Nothing;

    public Doc BreakAfterQueryOperator(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfterQueryOperator(token, Unbreakable)
            ? Doc.Line
            : Doc.Nothing;

    /// <summary>
    /// A break between the children of an XML element. This is the one kind of break that needs no
    /// permission: inside a literal a line ending is not a continuation but XML whitespace, and the
    /// compiler discards the whitespace between markup entirely. What it does need is a caller that
    /// has established there is no significant text here -- see <see cref="Xml.XmlWhitespace"/>.
    /// </summary>
    public Doc XmlContentBreak(bool broken) => broken ? Doc.HardLine : Doc.Nothing;

    /// <summary>
    /// The same, between the attributes of a tag, where XML wants at least one space -- so this one
    /// is a space rather than nothing while the tag stays flat.
    /// </summary>
    public Doc XmlTagBreak(bool broken) => broken ? Doc.HardLine : Doc.Space;

    /// <summary>
    /// What stands between two neighbours: a single space, or nothing where VB is written tight --
    /// see <see cref="Spacing"/>. A break here is never on offer; the rules obtain theirs from the
    /// methods above, which is what keeps one out of a position VB does not continue at.
    /// </summary>
    public Doc Gap(SyntaxNodeOrToken previous, SyntaxNodeOrToken next) =>
        Spacing.Required(
            previous.IsToken ? previous.AsToken() : previous.AsNode()!.GetLastToken(),
            next.IsToken ? next.AsToken() : next.AsNode()!.GetFirstToken()
        )
            ? Doc.Space
            : Doc.Nothing;

    /// <summary>The line break between two statements, blank when the author left a blank line.</summary>
    public Doc Separator(SyntaxNode node) => Separator(node.GetFirstToken());

    /// <inheritdoc cref="Separator(SyntaxNode)"/>
    public Doc Separator(SyntaxToken token) =>
        TriviaPrinter.BlankLinesBefore(token) > 0 ? Doc.EmptyLine : Doc.HardLine;
}
