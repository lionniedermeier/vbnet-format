using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Xml;

internal static class XmlAssignmentRule
{
    public static Doc? Tail(
        SyntaxToken op,
        ExpressionSyntax? value,
        VbDocVisitor visitor,
        FormatContext context)
    {
        if (value is null
            || !IsLayoutLiteral(value)
            || !ContinuationPoints.IsImplicitAfter(op)
            || StructuralFallback.MustPrintVerbatim(value))
        {
            return null;
        }

        return Doc.Group(
            context.Token(op),
            Doc.Indent(context.BreakAfter(op), visitor.Format(value)));
    }

    private static bool IsLayoutLiteral(ExpressionSyntax value) => value switch
    {
        XmlElementSyntax element => XmlWhitespace.IsFormattable(element),
        XmlEmptyElementSyntax => true,
        _ => false,
    };
}
