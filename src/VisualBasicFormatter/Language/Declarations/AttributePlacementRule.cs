using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

/// <summary>Whether an attribute list ends the line it stands on.</summary>
/// <remarks>
/// An attribute list is a child of the declaration it decorates rather than a member of its own, so
/// nothing puts it on a line by itself unless the walk over those children is asked to. That walk is
/// <see cref="StructuralFallback"/>, which every declaration statement kind goes through.
/// </remarks>
internal static class AttributePlacementRule
{
    /// <summary>
    /// The break behind <paramref name="previous"/>, or <c>null</c> when it is not an attribute list
    /// that takes a line of its own -- in which case the ordinary spacing applies.
    /// </summary>
    /// <param name="previous">The neighbour on the left.</param>
    /// <param name="next">The neighbour on the right, whose leading blank lines are honoured.</param>
    /// <param name="context">Options and the line break itself.</param>
    public static Doc? Break(SyntaxNodeOrToken previous, SyntaxNodeOrToken next, FormatContext context) =>
        previous.AsNode() is AttributeListSyntax list && StandsAlone(list)
            ? context.Separator(next.IsToken ? next.AsToken() : next.AsNode()!.GetFirstToken())
            : null;

    /// <summary>
    /// A declaration's attribute may take a line of its own. A parameter's may not -- it sits inside
    /// a bracketed list, where a line of its own is merely a worse layout -- and neither may a
    /// lambda's, which sits inside an expression. A lambda header counts as a declaration statement
    /// in the tree, so it has to be named rather than fall out of the test.
    /// </summary>
    private static bool StandsAlone(AttributeListSyntax list) =>
        list.Parent is DeclarationStatementSyntax and not LambdaHeaderSyntax;
}
