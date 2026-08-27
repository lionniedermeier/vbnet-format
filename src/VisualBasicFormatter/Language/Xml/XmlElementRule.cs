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
    public static Doc Format(
        XmlElementSyntax node,
        VbDocVisitor visitor,
        FormatContext context,
        bool broken)
    {
        var start = XmlTagRule.Format(node.StartTag, visitor, context, broken);
        var end = XmlTagRule.Format(node.EndTag, visitor, context);

        // Nothing between the tags means nothing to break for. The two breaks below would only put
        // the end tag on a line of its own.
        if (node.Content.Count == 0)
        {
            return Doc.Concat(start, end);
        }

        var items = Items(node.Content, visitor, context, broken);

        return broken
            ? Doc.Concat(
                start,
                Doc.Indent(context.XmlContentBreak(broken), items),
                context.XmlContentBreak(broken),
                end)
            : Doc.Concat(start, items, end);
    }

    private static Doc Items(
        SyntaxList<XmlNodeSyntax> content,
        VbDocVisitor visitor,
        FormatContext context,
        bool broken)
    {
        var items = ImmutableArray.CreateBuilder<Doc>();

        foreach (var child in content)
        {
            if (items.Count > 0)
            {
                items.Add(context.XmlContentBreak(broken));
            }

            items.Add(visitor.Format(child));
        }

        return Doc.Concat(items.DrainToImmutable());
    }
}
