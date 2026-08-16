using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Xml;

/// <summary>
/// An element with content: its start tag, its children one level deeper, and its end tag -- the
/// same shape <see cref="Statements.BlockRule"/> gives a VB block.
/// </summary>
internal static class XmlElementRule
{
    /// <summary>Lays out <paramref name="node"/>, whose content <see cref="XmlWhitespace"/> cleared.</summary>
    public static Doc Format(XmlElementSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        var start = visitor.Format(node.StartTag);
        var end = visitor.Format(node.EndTag);

        // Nothing between the tags means nothing to break for. The two breaks below would only put
        // the end tag on a line of its own.
        if (node.Content.Count == 0)
        {
            return Doc.Concat(start, end);
        }

        // Children one indent level in, the end tag back at the start tag's own depth. Content is
        // indented rather than aligned -- the opposite of the attributes in the tag, which
        // <see cref="XmlTagRule"/> aligns -- because that is what the style reference specifies and
        // what keeps a deeply placed literal from starving its own children of width.
        return Doc.Group(
            start,
            Doc.Indent(context.XmlContentBreak(), Doc.Concat(Items(node.Content, visitor, context))),
            context.XmlContentBreak(),
            end);
    }

    /// <summary>Child and separator in turn -- the shape a fill needs, and a concat accepts.</summary>
    private static ImmutableArray<Doc> Items(
        SyntaxList<XmlNodeSyntax> content,
        VbDocVisitor visitor,
        FormatContext context)
    {
        var items = ImmutableArray.CreateBuilder<Doc>();

        foreach (var child in content)
        {
            if (items.Count > 0)
            {
                items.Add(context.XmlContentBreak());
            }

            items.Add(visitor.Format(child));
        }

        return items.DrainToImmutable();
    }
}
