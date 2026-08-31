using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// What every formatting rule needs: the options, the line ending, and the source text the tree was
/// parsed from -- the latter only to read original columns, never to copy formatting decisions.
/// </summary>
internal sealed class FormatContext
{
    public FormatContext(FormatterOptions options, SourceText text, string newLine)
    {
        Options = options;
        Text = text;
        NewLine = newLine;

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

    /// <summary>The text the tree was parsed from.</summary>
    public SourceText Text { get; }

    /// <summary>Line ending of the output.</summary>
    public string NewLine { get; }

    /// <summary>The subset of <see cref="Options"/> the printer cares about.</summary>
    public PrintOptions PrintOptions { get; }

    /// <summary>
    /// A token with the comments that hang on it. The whitespace that separated it from its
    /// neighbours is deliberately not emitted: spacing is the rule's decision, not the input's.
    /// </summary>
    public Doc Token(SyntaxToken token) => Doc.Concat(
        TriviaPrinter.Leading(token, this),
        Doc.Text(token.Text),
        TriviaPrinter.Trailing(token, this));

    /// <summary>
    /// A break the language permits behind <paramref name="token"/>, rendered as a space while the
    /// group stays flat. This is the only way an expression rule can obtain a break, which is what
    /// keeps the printer from proposing one where VB forbids it.
    /// </summary>
    public Doc BreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token) ? Doc.Line : Doc.Nothing;

    /// <summary>The same, rendered as nothing while the group stays flat: behind <c>(</c> or a dot.</summary>
    public Doc SoftBreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token) ? Doc.SoftLine : Doc.Nothing;

    public bool EndsItsLine(SyntaxToken token)
    {
        var next = token.GetNextToken();

        return next != default
            && Text.Lines.GetLinePosition(token.Span.End).Line
                < Text.Lines.GetLinePosition(next.SpanStart).Line;
    }

    public Doc HardBreakAfter(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfter(token) ? Doc.HardLine : Doc.Space;

    /// <summary>
    /// A break the language permits in front of <paramref name="token"/>: a query clause head, or a
    /// closing bracket. Everywhere else the break belongs behind the token it follows.
    /// </summary>
    public Doc BreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token) ? Doc.Line : Doc.Nothing;

    /// <summary>
    /// The same, for a place where the two tokens must stay apart even when the break is refused:
    /// two keywords that would otherwise run together into a single word. Every other caller may
    /// take <see cref="Doc.Nothing"/> for an answer, because a refused break there only costs a
    /// layout -- here it would cost the code its meaning.
    /// </summary>
    public Doc SpacedBreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token) ? Doc.Line : Doc.Space;

    /// <summary>The same, rendered as nothing while the group stays flat: in front of a closing bracket.</summary>
    public Doc SoftBreakBefore(SyntaxToken token) =>
        ContinuationPoints.IsImplicitBefore(token) ? Doc.SoftLine : Doc.Nothing;

    public Doc BreakAfterQueryOperator(SyntaxToken token) =>
        ContinuationPoints.IsImplicitAfterQueryOperator(token) ? Doc.Line : Doc.Nothing;

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
    /// What stands between two neighbours: the spacing the pre-pass left, and nothing else. A break
    /// here is never on offer -- the rules obtain theirs from the methods above, which is what keeps
    /// one out of a position VB does not continue at.
    /// </summary>
    /// <param name="spaced">Whether anything stood between the two.</param>
    public Doc Gap(bool spaced) => spaced ? Doc.Space : Doc.Nothing;

    /// <summary>The line break between two statements, blank when the author left a blank line.</summary>
    public Doc Separator(SyntaxNode node) => Separator(node.GetFirstToken());

    /// <inheritdoc cref="Separator(SyntaxNode)"/>
    public Doc Separator(SyntaxToken token) =>
        TriviaPrinter.BlankLinesBefore(token) > 0 ? Doc.EmptyLine : Doc.HardLine;
}
