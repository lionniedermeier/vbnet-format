using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language.Xml;

internal static class XmlLayout
{
    public static bool IsBroken(XmlNodeSyntax element) =>
        !ReferenceEquals(Root(element), element) || HasElementDescendant(element);

    private static XmlNodeSyntax Root(XmlNodeSyntax node)
    {
        var root = node;

        for (var ancestor = node.Parent; ancestor is not null and not StatementSyntax; ancestor = ancestor.Parent)
        {
            if (ancestor is XmlNodeSyntax xml)
            {
                root = xml;
            }
        }

        return root;
    }

    private static bool HasElementDescendant(XmlNodeSyntax node) =>
        node.DescendantNodes().Any(child => child is XmlElementSyntax or XmlEmptyElementSyntax);
}
