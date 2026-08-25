using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

internal static class QueryAssignmentRule
{
    public static Doc? Tail(
        SyntaxToken op,
        ExpressionSyntax? value,
        VbDocVisitor visitor,
        FormatContext context)
    {
        if (value is not QueryExpressionSyntax query
            || !ContinuationPoints.IsImplicitAfter(op)
            || StructuralFallback.MustPrintVerbatim(query))
        {
            return null;
        }

        var body = QueryExpressionRule.Format(query, visitor, context, aligned: false);

        return body.Expands
            ? null
            : Doc.Group(context.Token(op), Doc.Indent(context.BreakAfter(op), body));
    }
}
