using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Declarations;

internal static class MemberSpacingRule
{
    public static Doc Format(
        Doc header,
        IReadOnlyList<StatementSyntax> preamble,
        SyntaxList<StatementSyntax> members,
        SyntaxNode footer,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        using var body = new DocListBuilder(2 * (preamble.Count + members.Count));

        StatementSyntax? previous = null;

        foreach (var statement in preamble)
        {
            body.Add(Doc.HardLine);
            body.Add(visitor.Format(statement));
            previous = statement;
        }

        foreach (var member in members)
        {
            body.Add(BeforeMember(previous, member, members.Count, context));
            body.Add(visitor.Format(member));
            previous = member;
        }

        return Doc.Concat(
            header,
            Doc.Indent(body.ToDoc()),
            BeforeFooter(members.Count),
            visitor.Format(footer)
        );
    }

    public static Doc Between(SyntaxNode previous, SyntaxNode next, FormatContext context) =>
        IsSeparated(previous) || IsSeparated(next) ? Doc.EmptyLine : context.Separator(next);

    private static Doc BeforeMember(
        StatementSyntax? previous,
        StatementSyntax member,
        int memberCount,
        FormatContext context
    ) =>
        previous switch
        {
            null => memberCount > 1 ? Doc.EmptyLine : Doc.HardLine,
            InheritsStatementSyntax or ImplementsStatementSyntax => Doc.EmptyLine,
            _ => Between(previous, member, context),
        };

    private static Doc BeforeFooter(int memberCount) =>
        memberCount > 1 ? Doc.EmptyLine : Doc.HardLine;

    private static bool IsSeparated(SyntaxNode member) =>
        member
            is MethodBlockBaseSyntax
                or PropertyBlockSyntax
                or EventBlockSyntax
                or TypeBlockSyntax
                or EnumBlockSyntax
                or NamespaceBlockSyntax
                or MethodStatementSyntax
                or SubNewStatementSyntax
                or OperatorStatementSyntax
                or DeclareStatementSyntax
                or DelegateStatementSyntax
                or EventStatementSyntax
        || IsDocumented(member);

    private static bool IsDocumented(SyntaxNode member)
    {
        foreach (var trivia in member.GetLeadingTrivia())
        {
            if (trivia.IsKind(SyntaxKind.DocumentationCommentTrivia))
            {
                return true;
            }
        }

        return false;
    }
}
