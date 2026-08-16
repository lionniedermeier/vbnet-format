using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Xml;

/// <summary>
/// The tags themselves, and the attributes inside them. An element without content is a tag and
/// nothing else, so it is laid out here too.
/// </summary>
internal static class XmlTagRule
{
    /// <summary>The start tag of an element: <c>&lt;name attr…&gt;</c>.</summary>
    public static Doc Format(XmlElementStartTagSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Tag(node.LessThanToken, node.Name, node.Attributes, node.GreaterThanToken, visitor, context);

    /// <summary>An element that is only a tag: <c>&lt;name attr…/&gt;</c>.</summary>
    public static Doc Format(XmlEmptyElementSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Tag(node.LessThanToken, node.Name, node.Attributes, node.SlashGreaterThanToken, visitor, context);

    /// <summary>The end tag: <c>&lt;/name&gt;</c>, which holds nothing that could break.</summary>
    public static Doc Format(XmlElementEndTagSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Doc.Concat(
            context.Token(node.LessThanSlashToken),
            visitor.Format(node.Name),
            context.Token(node.GreaterThanToken));

    /// <summary><c>name="value"</c>. XML permits spaces around the <c>=</c>; none are written.</summary>
    public static Doc Format(XmlAttributeSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Doc.Concat(
            visitor.Format(node.Name),
            context.Token(node.EqualsToken),
            visitor.Format(node.Value));

    private static Doc Tag(
        SyntaxToken open,
        XmlNodeSyntax name,
        SyntaxList<XmlNodeSyntax> attributes,
        SyntaxToken close,
        VbDocVisitor visitor,
        FormatContext context)
    {
        var head = Doc.Concat(context.Token(open), visitor.Format(name));

        if (attributes.Count == 0)
        {
            return Doc.Concat(head, context.Token(close));
        }

        // Attributes align under the first one, which is the established XML convention and what the
        // style reference specifies. It is safe here in a way it would not be for VB code: the tag
        // name is stable, where a method name that alignment hangs off is renamed all the time.
        //
        // A group of its own: whether the attributes of this tag fit is a separate question from
        // whether the element's content does.
        //
        // The space is what puts the column Align pins behind the tag name rather than on it.
        return Doc.Group(
            head,
            Doc.Space,
            Doc.Align(Doc.Concat(Items(attributes, visitor, context))),
            context.Token(close));
    }

    /// <summary>
    /// Attribute and separator in turn. Unlike the comma of an argument list the separator here is
    /// whitespace, so it has to stay a space when the tag does not break.
    /// </summary>
    private static ImmutableArray<Doc> Items(
        SyntaxList<XmlNodeSyntax> attributes,
        VbDocVisitor visitor,
        FormatContext context)
    {
        var items = ImmutableArray.CreateBuilder<Doc>();

        foreach (var attribute in attributes)
        {
            if (items.Count > 0)
            {
                items.Add(context.XmlTagBreak());
            }

            items.Add(visitor.Format(attribute));
        }

        return items.DrainToImmutable();
    }
}
