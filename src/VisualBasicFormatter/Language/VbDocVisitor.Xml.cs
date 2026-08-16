using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Xml;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// XML literals. Their line breaks are not continuations but insignificant XML whitespace, so these
/// rules obtain a break from <see cref="FormatContext.XmlContentBreak"/> rather than from
/// <see cref="FormatContext.BreakAfter"/> -- see <see cref="XmlWhitespace"/> for why that is safe.
/// </summary>
/// <remarks>
/// Every node kind a literal can contain has a rule here. That is deliberate: the structural
/// fallback re-decides the spacing between children, and inside markup the space between two tokens
/// is a character of the document rather than a formatting decision.
/// </remarks>
internal sealed partial class VbDocVisitor
{
    /// <summary>
    /// An element whose content is significant text keeps every character it has; only where
    /// <see cref="XmlWhitespace.IsFormattable"/> holds is the layout the formatter's to decide.
    /// </summary>
    public override Doc VisitXmlElement(XmlElementSyntax node) =>
        XmlWhitespace.IsFormattable(node)
            ? XmlElementRule.Format(node, this, _context)
            : Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitXmlEmptyElement(XmlEmptyElementSyntax node) =>
        XmlTagRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitXmlElementStartTag(XmlElementStartTagSyntax node) =>
        XmlTagRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitXmlElementEndTag(XmlElementEndTagSyntax node) =>
        XmlTagRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitXmlAttribute(XmlAttributeSyntax node) =>
        XmlTagRule.Format(node, this, _context);

    /// <summary>
    /// <c>&lt;%= expression %&gt;</c>. Inside it the ordinary VB rules apply again -- a query, a
    /// chain or an argument list breaks there exactly as it would outside a literal.
    /// </summary>
    public override Doc VisitXmlEmbeddedExpression(XmlEmbeddedExpressionSyntax node) => Doc.Concat(
        _context.Token(node.LessThanPercentEqualsToken),
        Doc.Space,
        Format(node.Expression),
        Doc.Space,
        _context.Token(node.PercentGreaterThanToken));

    /// <inheritdoc/>
    public override Doc VisitXmlName(XmlNameSyntax node) =>
        Doc.Concat(Format(node.Prefix), _context.Token(node.LocalName));

    /// <inheritdoc/>
    public override Doc VisitXmlPrefix(XmlPrefixSyntax node) =>
        Doc.Concat(_context.Token(node.Name), _context.Token(node.ColonToken));

    /// <summary>A name in angle brackets, as an axis property writes it: <c>doc.&lt;item&gt;</c>.</summary>
    public override Doc VisitXmlBracketedName(XmlBracketedNameSyntax node) => Doc.Concat(
        _context.Token(node.LessThanToken),
        Format(node.Name),
        _context.Token(node.GreaterThanToken));

    // Content whose own characters are the point. Each may legally span lines -- an attribute value
    // as much as a CDATA section -- which no Doc.Text may, so all of them go to the verbatim
    // printer that keeps their columns.

    /// <inheritdoc/>
    public override Doc VisitXmlString(XmlStringSyntax node) => Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitXmlText(XmlTextSyntax node) => Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitXmlComment(XmlCommentSyntax node) => Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node) =>
        Verbatim(node);
}
