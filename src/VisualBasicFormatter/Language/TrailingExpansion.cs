using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language;

/// <summary>
/// Two questions about an element of a list: whether it may be broken open on its own before the
/// separators in front of it are broken, and whether it brings its own indented body and so cannot
/// be laid out behind the bracket at all.
/// </summary>
/// <remarks>
/// The outer list breaks first: splitting the separators in front of an element is preferred over
/// opening up the element itself, the same way "a comma outranks an operator" prefers splitting a
/// list over splitting a <see cref="BinaryExpressionSyntax"/> inside one of its elements. This list
/// is the one deliberate exception -- an element whose own body is a brace or a lambda header reads
/// as a continuation of the call it sits in, not as a value the call is passing, so it is still
/// hugged: <c>Foo(a, Function(x) LongCall(y, z))</c> and <c>Foo(a, New Bar With {...})</c> stay
/// glued to their bracket rather than dropping to a line of their own. A trailing call, ternary
/// <c>If</c>, or query has no such body -- it is laid out beneath the bracket exactly like
/// everything that isn't last, once <see cref="IsExpandable"/> answers <see langword="false"/> for
/// it.
/// </remarks>
internal static class TrailingExpansion
{
    /// <summary>Whether <paramref name="element"/> offers a break worth trying on its own.</summary>
    public static bool IsExpandable(SyntaxNode element) => Inner(element) switch
    {
        ObjectCreationExpressionSyntax creation => creation.Initializer is not null,
        ArrayCreationExpressionSyntax
            or AnonymousObjectCreationExpressionSyntax
            or CollectionInitializerSyntax
            or LambdaExpressionSyntax => true,
        _ => false,
    };

    /// <summary>
    /// Whether <paramref name="element"/> brings its own indented body -- a multi-line lambda. Such
    /// an element cannot be laid out behind the bracket that holds it: wherever the bracket happens
    /// to end, its body would start one level further in, and its statements would have that much
    /// less width left. <see cref="VbDocBuilder"/> keeps a list holding one at
    /// <see cref="ListLayout.OnePerLine"/> for that reason, whatever layout the list otherwise asks
    /// for.
    /// </summary>
    /// <remarks>
    /// A multi-line lambda always contributes a hard line break of its own (its <c>End Function</c>
    /// is a statement like any other, see <see cref="Statements.StatementListRule"/>), so a list
    /// holding one always has <see cref="Printing.Doc.Expands"/> set. It therefore never reaches the
    /// conditional-group ladder <see cref="IsExpandable"/> feeds, and
    /// <see cref="Printing.Doc.ForceBreak(Printing.Doc)"/> never has to walk into the layout this
    /// predicate selects -- keep it that way if this predicate is ever widened further.
    /// <para>
    /// This predicate used to exclude multi-line <c>Sub</c> lambdas, because moving a <c>Sub</c>
    /// header onto its own line once made <c>SyntaxNode.IsEquivalentTo</c> report a false difference
    /// that <see cref="VbFormatter"/> turns into a refusal to format the file. On Roslyn 5.6.0 an
    /// isolated repro no longer shows it -- <c>Sub</c> and <c>Function</c> lambdas both compare
    /// equivalent across the move -- so the exclusion is gone and the layout now matches the lambda
    /// example in <c>docs/standard_format.md</c>. If a file ever comes back with "Formatting changed
    /// the code" and a <c>Sub</c> lambda argument in it, this is the first place to look.
    /// </para>
    /// </remarks>
    public static bool IsBlock(SyntaxNode element) => Inner(element) is MultiLineLambdaExpressionSyntax;

    /// <summary>The expression an element carries, past whatever wraps it in the list.</summary>
    private static SyntaxNode? Inner(SyntaxNode? element) => element switch
    {
        SimpleArgumentSyntax argument => Inner(argument.Expression),
        NamedFieldInitializerSyntax field => Inner(field.Expression),
        InferredFieldInitializerSyntax field => Inner(field.Expression),
        ParenthesizedExpressionSyntax parenthesized => Inner(parenthesized.Expression),
        _ => element,
    };
}
