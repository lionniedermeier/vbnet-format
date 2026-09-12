using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Statements;

internal static class CaseStatementRule
{
    public static Doc Format(
        CaseStatementSyntax node,
        VbDocVisitor visitor,
        FormatContext context
    ) =>
        Doc.Concat(
            context.Token(node.CaseKeyword),
            Doc.Space,
            Doc.Indent(VbDocBuilder.Run(node.Cases, visitor, context))
        );
}
