using Microsoft.CodeAnalysis;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Statements;

/// <summary>
/// The shape every VB block has: a header line, a body one level deeper, and a closing statement
/// back at the header's indent. The node types do not share a base that exposes those three parts,
/// so each block rule reads its own properties and hands them here.
/// </summary>
internal static class BlockRule
{
    /// <summary>header, indented body, footer.</summary>
    public static Doc Format(
        Doc header,
        IEnumerable<SyntaxNode> body,
        SyntaxNode? footer,
        VbDocVisitor visitor,
        FormatContext context) =>
        Doc.Concat(header, Body(body, visitor, context), StatementListRule.Format(footer, visitor, context));

    /// <summary>The body of a block, one level deeper than its header.</summary>
    public static Doc Body(IEnumerable<SyntaxNode> body, VbDocVisitor visitor, FormatContext context) =>
        Doc.Indent(StatementListRule.Format(body, visitor, context));
}
