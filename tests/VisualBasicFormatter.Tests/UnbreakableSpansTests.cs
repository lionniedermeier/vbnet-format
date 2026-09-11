using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language;

namespace VisualBasicFormatter.Tests;

/// <summary>
/// <see cref="UnbreakableSpans"/> replaces an ancestor walk with a precomputed index. This checks it
/// agrees with the walk it replaced on every token of every golden fixture, plus the nesting shapes
/// the fixtures do not happen to exercise.
/// </summary>
public sealed class UnbreakableSpansTests
{
    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void AgreesWithTheAncestorWalk_OnEveryFixture(string name) =>
        AssertAgreement(TestCases.ReadInput(name));

    [Theory]
    [InlineData(
        """
            Module M
                Sub S()
                    Dim x = $"a{1}b{2}c"
                End Sub
            End Module
            """
    )]
    [InlineData(
        """
            Module M
                Sub S()
                    Dim x = <a><%= <b/> %></a>
                End Sub
            End Module
            """
    )]
    [InlineData(
        """
            Module M
                Sub S()
                    Dim x = <a><%= <b><%= y %></b> %></a>
                End Sub
            End Module
            """
    )]
    [InlineData(
        """
            Module M
                Sub S()
                    If a Then If b Then Console.WriteLine("x") Else Console.WriteLine("y")
                End Sub
            End Module
            """
    )]
    [InlineData(
        """
            Module M
            #If DEBUG Then
                Sub S()
                End Sub
            #End If
            End Module
            """
    )]
    [InlineData(
        """
            Module M
                Sub S()
                    Dim x = <a><%= From i In items Where i > 0 Select i %></a>
                End Sub
            End Module
            """
    )]
    public void AgreesWithTheAncestorWalk_OnNestingEdgeCases(string source) =>
        AssertAgreement(source);

    private static void AssertAgreement(string source)
    {
        var root = VisualBasicSyntaxTree.ParseText(source).GetRoot();
        var (_, unbreakable) = UnbreakableSpans.Build(root);

        foreach (var token in root.DescendantTokens())
        {
            Assert.Equal(
                IsInsideUnbreakableByWalking(token),
                unbreakable.Contains(token.SpanStart)
            );
        }
    }

    /// <summary>The ancestor walk <see cref="UnbreakableSpans"/> was written to replace.</summary>
    private static bool IsInsideUnbreakableByWalking(SyntaxToken token)
    {
        for (var node = token.Parent; node is not null; node = node.Parent)
        {
            if (node is XmlEmbeddedExpressionSyntax)
            {
                return false;
            }

            if (
                node
                is InterpolatedStringExpressionSyntax
                    or XmlNodeSyntax
                    or DirectiveTriviaSyntax
                    or SingleLineIfStatementSyntax
            )
            {
                return true;
            }
        }

        return false;
    }
}
