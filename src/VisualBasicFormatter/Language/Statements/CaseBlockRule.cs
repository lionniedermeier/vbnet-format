using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Statements;

internal static class CaseBlockRule
{
    public static Doc Format(CaseBlockSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        var header = visitor.Format(node.CaseStatement);
        var expanded = Doc.Concat(header, BlockRule.Body(node.Statements, visitor, context));

        if (node.Statements.Count != 1 || !WrittenOnTheCaseLine(node))
        {
            return expanded;
        }

        var body = visitor.Format(node.Statements[0]);

        if (body.Expands)
        {
            return expanded;
        }

        return Doc.ConditionalGroup(Doc.Concat(header, Doc.Text(" : "), body), expanded);
    }

    private static bool WrittenOnTheCaseLine(CaseBlockSyntax node)
    {
        var end = node.CaseStatement.Span.End;
        var start = node.Statements[0].SpanStart;

        foreach (var trivia in node.DescendantTrivia())
        {
            if (trivia.SpanStart < end)
            {
                continue;
            }

            if (trivia.SpanStart >= start)
            {
                break;
            }

            if (trivia.IsKind(SyntaxKind.EndOfLineTrivia))
            {
                return false;
            }
        }

        return true;
    }
}
