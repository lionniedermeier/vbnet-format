using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Expressions;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// The constructs that may be broken across lines. Everything here goes through
/// <see cref="FormatContext.BreakAfter"/>, which refuses any token VB does not continue implicitly.
/// </summary>
internal sealed partial class VbDocVisitor
{
    /// <summary>Dots the chain rule decided to break at, looked up again on the way down.</summary>
    private readonly HashSet<SyntaxToken> _chainBreaks = [];

    /// <inheritdoc/>
    public override Doc VisitArgumentList(ArgumentListSyntax node) => VbDocBuilder.List(
        node.OpenParenToken, node.Arguments, node.CloseParenToken, ListLayout.Packed, this, _context);

    /// <inheritdoc/>
    public override Doc VisitParameterList(ParameterListSyntax node) => VbDocBuilder.List(
        node.OpenParenToken, node.Parameters, node.CloseParenToken, ListLayout.Packed, this, _context);

    /// <summary>Rare and short, so a line of its own per type parameter costs nothing.</summary>
    public override Doc VisitTypeParameterList(TypeParameterListSyntax node) => VbDocBuilder.List(
        node.OpenParenToken,
        Doc.Concat(_context.Token(node.OfKeyword), Doc.Space),
        node.Parameters,
        node.CloseParenToken,
        ListLayout.OnePerLine,
        this,
        _context);

    /// <inheritdoc cref="VisitTypeParameterList"/>
    public override Doc VisitTypeArgumentList(TypeArgumentListSyntax node) => VbDocBuilder.List(
        node.OpenParenToken,
        Doc.Concat(_context.Token(node.OfKeyword), Doc.Space),
        node.Arguments,
        node.CloseParenToken,
        ListLayout.OnePerLine,
        this,
        _context);

    /// <inheritdoc cref="VisitTypeParameterList"/>
    public override Doc VisitAttributeList(AttributeListSyntax node) => VbDocBuilder.List(
        node.LessThanToken, node.Attributes, node.GreaterThanToken, ListLayout.OnePerLine, this, _context);

    /// <summary>
    /// The braces of an array literal, a collection initializer or a <c>From</c> clause. One element
    /// per line: an added element is then a one-line diff rather than a reflow of the whole literal.
    /// </summary>
    public override Doc VisitCollectionInitializer(CollectionInitializerSyntax node) => VbDocBuilder.List(
        node.OpenBraceToken, node.Initializers, node.CloseBraceToken, ListLayout.OnePerLine, this, _context);

    /// <summary>One member per line, so the initializer reads as the list of assignments it is.</summary>
    public override Doc VisitObjectMemberInitializer(ObjectMemberInitializerSyntax node) => Doc.Concat(
        _context.Token(node.WithKeyword),
        Doc.Space,
        VbDocBuilder.List(
            node.OpenBraceToken,
            node.Initializers,
            node.CloseBraceToken,
            ListLayout.OnePerLine,
            this,
            _context));

    /// <summary>
    /// <c>If(condition, whenTrue, whenFalse)</c>. Its commas are children of the expression rather
    /// than a list of their own, but they are the same continuation point an argument list breaks
    /// at, so it is laid out as one.
    /// </summary>
    public override Doc VisitTernaryConditionalExpression(TernaryConditionalExpressionSyntax node) =>
        Conditional(
            node.IfKeyword,
            node.OpenParenToken,
            [node.Condition, node.WhenTrue, node.WhenFalse],
            [node.FirstCommaToken, node.SecondCommaToken],
            node.CloseParenToken);

    /// <summary>The two-argument <c>If(value, fallback)</c>.</summary>
    public override Doc VisitBinaryConditionalExpression(BinaryConditionalExpressionSyntax node) =>
        Conditional(
            node.IfKeyword,
            node.OpenParenToken,
            [node.FirstExpression, node.SecondExpression],
            [node.CommaToken],
            node.CloseParenToken);

    private Doc Conditional(
        SyntaxToken ifKeyword,
        SyntaxToken open,
        ImmutableArray<ExpressionSyntax> operands,
        ImmutableArray<SyntaxToken> commas,
        SyntaxToken close) =>
        Doc.Concat(
            _context.Token(ifKeyword),
            VbDocBuilder.List(
                open,
                Doc.Nothing,
                [.. operands.Select(Format)],
                commas,
                close,
                TrailingExpansion.IsExpandable(operands[^1]),
                operands.Any(TrailingExpansion.IsBlock),
                ListLayout.Packed,
                _context));

    /// <summary>
    /// The outermost call of a chain owns the chain: it marks the dots to break at and wraps the
    /// whole run, so the links below it only have to honour the marks.
    /// </summary>
    public override Doc VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        var dots = MemberChainRule.BreakDots(node);

        if (dots.IsEmpty)
        {
            return StructuralFallback.Format(node, this, _context);
        }

        foreach (var dot in dots)
        {
            _chainBreaks.Add(dot);
        }

        return VbDocBuilder.Run(StructuralFallback.Format(node, this, _context));
    }

    /// <summary>
    /// A link of a chain the rule above marked. Every other member access is left to the structural
    /// fallback, so that a plain property hop keeps whatever break opportunities that offers.
    /// </summary>
    public override Doc VisitMemberAccessExpression(MemberAccessExpressionSyntax node) =>
        _chainBreaks.Contains(node.OperatorToken)
            ? Doc.Concat(
                Format(node.Expression),
                _context.Token(node.OperatorToken),
                _context.SoftBreakAfter(node.OperatorToken),
                Format(node.Name))
            : StructuralFallback.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitQueryExpression(QueryExpressionSyntax node) =>
        QueryExpressionRule.Format(node, this, _context);

    public override Doc VisitEqualsValue(EqualsValueSyntax node) =>
        QueryAssignmentRule.Tail(node.EqualsToken, node.Value, this, _context)
        ?? StructuralFallback.Format(node, this, _context);

    public override Doc VisitAssignmentStatement(AssignmentStatementSyntax node) =>
        !StructuralFallback.MustPrintVerbatim(node)
        && QueryAssignmentRule.Tail(node.OperatorToken, node.Right, this, _context) is { } tail
            ? Doc.Concat(Format(node.Left), Doc.Space, tail)
            : StructuralFallback.Format(node, this, _context);

    /// <inheritdoc cref="JoinClauseRule"/>
    public override Doc VisitSimpleJoinClause(SimpleJoinClauseSyntax node) =>
        JoinClauseRule.Format(node, this, _context);

    /// <inheritdoc cref="JoinClauseRule"/>
    public override Doc VisitGroupJoinClause(GroupJoinClauseSyntax node) =>
        JoinClauseRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitBinaryExpression(BinaryExpressionSyntax node) =>
        BinaryExpressionRule.IsRunHead(node)
            ? BinaryExpressionRule.Format(node, this, _context)
            : StructuralFallback.Format(node, this, _context);
}
