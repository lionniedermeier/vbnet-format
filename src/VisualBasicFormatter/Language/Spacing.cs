using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language;

/// <summary>
/// Whether two adjacent tokens are written with a space between them. This is what the structural
/// fallback consults where it once copied whatever the author left: the default is a single space,
/// and the cases below are the exceptions where VB is written tight.
/// </summary>
/// <remarks>
/// Only the token pairs the fallback actually reaches pass through here. Bracketed lists, binary
/// operator runs and the block skeleton emit their own spacing directly and never ask.
/// </remarks>
internal static class Spacing
{
    /// <summary>Whether a space belongs between <paramref name="previous"/> and <paramref name="next"/>.</summary>
    public static bool Required(SyntaxToken previous, SyntaxToken next)
    {
        var before = previous.Kind();
        var after = next.Kind();

        // An XML namespace import is markup: "<xmlns:p="urn">" is written with no inner spaces, and
        // a space after the "<" makes VB parse it as something else entirely. The space between the
        // "Imports" keyword and the "<" is left to the default.
        if (
            before is SyntaxKind.LessThanToken
            && previous.Parent is XmlNamespaceImportsClauseSyntax
        )
        {
            return false;
        }

        if (after is SyntaxKind.GreaterThanToken && next.Parent is XmlNamespaceImportsClauseSyntax)
        {
            return false;
        }

        // A member qualifier, a dictionary-lookup bang and an XML attribute-axis "@" bind tight on
        // both sides.
        if (before is SyntaxKind.DotToken or SyntaxKind.ExclamationToken or SyntaxKind.AtToken)
        {
            return false;
        }

        if (after is SyntaxKind.DotToken or SyntaxKind.ExclamationToken or SyntaxKind.AtToken)
        {
            return false;
        }

        // Nothing stands in front of a separator.
        if (after is SyntaxKind.CommaToken or SyntaxKind.ColonToken or SyntaxKind.SemicolonToken)
        {
            return false;
        }

        // Brackets hug their contents.
        if (before is SyntaxKind.OpenParenToken or SyntaxKind.OpenBraceToken)
        {
            return false;
        }

        if (after is SyntaxKind.CloseParenToken or SyntaxKind.CloseBraceToken)
        {
            return false;
        }

        // A trailing "?" is part of the type it nullifies; a ":=" glues a name to its argument.
        if (after is SyntaxKind.QuestionToken or SyntaxKind.ColonEqualsToken)
        {
            return false;
        }

        if (before is SyntaxKind.ColonEqualsToken)
        {
            return false;
        }

        // An opening parenthesis is glued to what it follows when it heads a call, a declaration
        // list, a type argument list, an array rank or one of the cast/intrinsic expressions.
        if (after is SyntaxKind.OpenParenToken && GluedOpenParen(next))
        {
            return false;
        }

        // The operand of a sign is glued to it; "Not" and "AddressOf" are words and take a space.
        if (
            before is SyntaxKind.MinusToken or SyntaxKind.PlusToken
            && previous.Parent is UnaryExpressionSyntax
        )
        {
            return false;
        }

        return true;
    }

    private static bool GluedOpenParen(SyntaxToken openParen) =>
        openParen.Parent
            is ArgumentListSyntax
                or ParameterListSyntax
                or TypeArgumentListSyntax
                or TypeParameterListSyntax
                or ArrayRankSpecifierSyntax
                or FunctionAggregationSyntax
                or CastExpressionSyntax
                or PredefinedCastExpressionSyntax
                or GetTypeExpressionSyntax
                or NameOfExpressionSyntax
                or GetXmlNamespaceExpressionSyntax;
}
