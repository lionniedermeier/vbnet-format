using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language;

/// <summary>
/// Where VB lets a line end without a trailing underscore. This is the whole reason a document
/// printer cannot be pointed at VB unchanged: in a language with free parenthesisation a break is
/// legal almost anywhere, here it is legal only after the tokens listed below.
/// </summary>
/// <remarks>
/// The list is closed and unknown kinds answer <c>false</c>, so a rule that asks about a token
/// nobody thought about gets no break rather than invalid code.
/// </remarks>
internal static class ContinuationPoints
{
    /// <summary>
    /// Binary operators VB documents as implicit continuation points. Integer division <c>\</c> and
    /// the comparison <c>=</c> are deliberately absent: they are not on that list, and leaving them
    /// out costs nothing.
    /// </summary>
    private static readonly HashSet<SyntaxKind> Operators =
    [
        SyntaxKind.PlusToken,
        SyntaxKind.MinusToken,
        SyntaxKind.AsteriskToken,
        SyntaxKind.SlashToken,
        SyntaxKind.CaretToken,
        SyntaxKind.AmpersandToken,
        SyntaxKind.ModKeyword,
        SyntaxKind.LessThanLessThanToken,
        SyntaxKind.GreaterThanGreaterThanToken,
        SyntaxKind.LessThanGreaterThanToken,
        SyntaxKind.LessThanToken,
        SyntaxKind.GreaterThanToken,
        SyntaxKind.LessThanEqualsToken,
        SyntaxKind.GreaterThanEqualsToken,
        SyntaxKind.AndKeyword,
        SyntaxKind.AndAlsoKeyword,
        SyntaxKind.OrKeyword,
        SyntaxKind.OrElseKeyword,
        SyntaxKind.XorKeyword,
        SyntaxKind.LikeKeyword,
        SyntaxKind.IsKeyword,
        SyntaxKind.IsNotKeyword,
    ];

    /// <summary>Whether a line may end right behind <paramref name="token"/>.</summary>
    public static bool IsImplicitAfter(SyntaxToken token)
    {
        if (IsInsideUnbreakable(token))
        {
            return false;
        }

        return token.Kind() switch
        {
            SyntaxKind.CommaToken => true,
            SyntaxKind.OpenParenToken => true,
            SyntaxKind.OpenBraceToken => true,
            SyntaxKind.DotToken => IsBreakableDot(token),

            // Legal, but it only puts the bracket alone on a line; the commas inside do the work.
            // Answered here rather than left out, because the comparison < is in Operators below.
            SyntaxKind.LessThanToken when token.Parent is AttributeListSyntax => false,
            var kind => Operators.Contains(kind),
        };
    }

    /// <summary>
    /// Whether a line may end right in front of <paramref name="token"/>. VB continues implicitly
    /// before a token in three places: the keyword that opens a query clause, a closing parenthesis
    /// and a closing curly brace. The latter two are what let a list put its closing bracket on a
    /// line of its own, below a block element that could not have stood behind it.
    /// </summary>
    public static bool IsImplicitBefore(SyntaxToken token)
    {
        if (IsInsideUnbreakable(token))
        {
            return false;
        }

        return token.Kind() switch
        {
            SyntaxKind.CloseParenToken => true,
            SyntaxKind.CloseBraceToken => true,
            _ => IsQueryClauseHead(token),
        };
    }

    /// <summary>
    /// Whether <paramref name="token"/> is one of a query clause's own keywords. VB continues
    /// implicitly <em>before and after</em> a query operator, so a line may end right behind one
    /// with no marker at all -- the mirror image of <see cref="IsQueryClauseHead"/>, which is what
    /// breaks a query in front of its clauses.
    /// </summary>
    /// <remarks>
    /// Kept apart from <see cref="IsImplicitAfter"/> on purpose. That one also answers for
    /// <see cref="FormatContext.Gap"/>, where a wider list would move the last-resort underscore in
    /// files that have nothing to do with XML.
    /// </remarks>
    public static bool IsImplicitAfterQueryOperator(SyntaxToken token) =>
        token.Parent is QueryClauseSyntax && !IsInsideUnbreakable(token);

    /// <summary>Whether a run of <paramref name="token"/> may be broken after each of its operators.</summary>
    public static bool IsBreakableOperator(SyntaxToken token) =>
        Operators.Contains(token.Kind()) && !IsInsideUnbreakable(token);

    /// <summary>
    /// Whether <paramref name="token"/> sits in XML markup rather than in VB code. An underscore
    /// there would be XML text, not a line continuation, so it must never be offered -- while a
    /// plain line break needs no marker at all, which is what the XML rules make use of.
    /// </summary>
    public static bool IsInsideXmlMarkup(SyntaxToken token) => EnclosingXml(token) is not null;

    /// <summary>
    /// A dot qualifies only when something stands in front of it. A leading dot belongs to a
    /// <c>With</c> block, to an initializer key or to a conditional access, and those are exactly
    /// the places where VB does demand an underscore. Breaking inside a qualified name is legal but
    /// splits a type across lines for no gain, so it is refused too.
    /// </summary>
    private static bool IsBreakableDot(SyntaxToken token) => token.Parent switch
    {
        MemberAccessExpressionSyntax access => access.Expression is not null,
        _ => false,
    };

    /// <summary>
    /// Whether <paramref name="token"/> opens a query clause: the <c>From</c>, <c>Where</c>,
    /// <c>Select</c>, <c>Order</c>, <c>Group</c> and so on that a query is written one per line at.
    /// The keywords inside a clause -- <c>In</c>, <c>Into</c>, <c>On</c> -- are continuation points
    /// too, but breaking there splits a clause for no gain, so only its head is offered.
    /// </summary>
    private static bool IsQueryClauseHead(SyntaxToken token)
    {
        for (var node = token.Parent; node is not null; node = node.Parent)
        {
            if (node is QueryClauseSyntax clause)
            {
                return clause.GetFirstToken() == token;
            }

            if (node is QueryExpressionSyntax)
            {
                return false;
            }
        }

        return false;
    }

    /// <summary>
    /// Constructs whose text is one lexical unit, or whose line breaks would change the tree. None
    /// of them is ever taken apart, so no break may be offered inside one either. A single-line
    /// lambda is not among them: its body is an ordinary expression and continues implicitly.
    /// </summary>
    private static bool IsInsideUnbreakable(SyntaxToken token)
    {
        for (var node = token.Parent; node is not null; node = node.Parent)
        {
            // An embedded expression is ordinary VB again, so the continuation points above apply to
            // it unchanged -- and it is reached before the literal around it, which is what lets a
            // query inside <%= %> break at its clauses while the markup stays the XML rules' own.
            if (node is XmlEmbeddedExpressionSyntax)
            {
                return false;
            }

            if (node is InterpolatedStringExpressionSyntax
                or XmlNodeSyntax
                or DirectiveTriviaSyntax
                or SingleLineIfStatementSyntax)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// The XML literal <paramref name="token"/> is markup of, or <c>null</c> when it is VB code --
    /// including the code inside an embedded expression, which is reached first on the way up.
    /// </summary>
    private static XmlNodeSyntax? EnclosingXml(SyntaxToken token)
    {
        for (var node = token.Parent; node is not null; node = node.Parent)
        {
            if (node is XmlEmbeddedExpressionSyntax)
            {
                return null;
            }

            if (node is XmlNodeSyntax xml)
            {
                return xml;
            }
        }

        return null;
    }
}
