using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

/// <summary>
/// <c>Module</c>, <c>Class</c>, <c>Structure</c> and <c>Interface</c>. They differ only in their
/// keywords, which sit in the header statement, so one rule covers all four.
/// </summary>
internal static class TypeBlockRule
{
    /// <summary>Prints <paramref name="node"/>.</summary>
    public static Doc Format(TypeBlockSyntax node, VbDocVisitor visitor, FormatContext context) =>
        MemberSpacingRule.Format(
            visitor.Format(node.BlockStatement),
            [.. node.Inherits, .. node.Implements],
            node.Members,
            node.EndBlockStatement,
            visitor,
            context
        );
}
