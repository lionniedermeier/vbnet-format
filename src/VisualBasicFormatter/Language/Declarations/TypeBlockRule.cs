using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Statements;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

/// <summary>
/// <c>Module</c>, <c>Class</c>, <c>Structure</c> and <c>Interface</c>. They differ only in their
/// keywords, which sit in the header statement, so one rule covers all four.
/// </summary>
internal static class TypeBlockRule
{
    /// <summary>Prints <paramref name="node"/>.</summary>
    public static Doc Format(TypeBlockSyntax node, VbDocVisitor visitor, FormatContext context) => Doc.Concat(
        visitor.Format(node.BlockStatement),
        Doc.Indent(Doc.Concat(
            StatementListRule.Format(node.Inherits, visitor, context),
            StatementListRule.Format(node.Implements, visitor, context),
            StatementListRule.Format(node.Members, visitor, context))),
        StatementListRule.Format(node.EndBlockStatement, visitor, context));
}
