using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Xml;

internal static class XmlLiteralRule
{
    public static Doc Format(XmlElementSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Choose(node, broken => XmlElementRule.Format(node, visitor, context, broken));

    public static Doc Format(XmlEmptyElementSyntax node, VbDocVisitor visitor, FormatContext context) =>
        Choose(node, broken => XmlTagRule.Format(node, visitor, context, broken));

    private static Doc Choose(XmlNodeSyntax node, Func<bool, Doc> build) =>
        XmlLayout.IsBroken(node)
            ? build(true)
            : Doc.ConditionalGroup(build(false), build(true));
}
