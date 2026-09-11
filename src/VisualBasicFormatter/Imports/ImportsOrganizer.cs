using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Imports;

/// <summary>
/// Sorts, deduplicates and groups the <c>Imports</c> statements of a file.
/// Unused imports are deliberately not removed: that would need a <see cref="SemanticModel"/> with
/// resolved references, which a formatter working one file at a time does not have.
/// </summary>
public static class ImportsOrganizer
{
    private static readonly SyntaxToken ImportsKeyword = SyntaxFactory
        .Token(SyntaxKind.ImportsKeyword)
        .WithTrailingTrivia(SyntaxFactory.Space);

    private enum ImportGroup
    {
        Namespace,
        Alias,
        Xml,
    }

    /// <summary>Reorders the imports of <paramref name="root"/>.</summary>
    public static CompilationUnitSyntax Organize(CompilationUnitSyntax root, string newLine)
    {
        if (root.Imports.Count == 0)
        {
            return root;
        }

        var statements = new List<ImportsStatementSyntax>(root.Imports.Count);
        var headerTaken = false;

        foreach (var segment in Segments(root.Imports))
        {
            if (segment.IsVerbatim)
            {
                statements.AddRange(segment.Statements);
                headerTaken = true;
                continue;
            }

            List<SyntaxTrivia> header = headerTaken
                ? []
                : ExtractFileHeader(segment.Statements[0]);
            headerTaken = true;
            statements.AddRange(Sorted(segment.Statements, header, newLine));
        }

        return root.WithImports(SyntaxFactory.List(statements));
    }

    private readonly record struct Segment(bool IsVerbatim, List<ImportsStatementSyntax> Statements);

    private static IEnumerable<Segment> Segments(SyntaxList<ImportsStatementSyntax> imports)
    {
        List<ImportsStatementSyntax>? current = null;

        foreach (var statement in imports)
        {
            if (statement.ContainsDirectives)
            {
                if (current is not null)
                {
                    yield return new Segment(false, current);
                    current = null;
                }

                yield return new Segment(true, [statement]);
                continue;
            }

            current ??= [];
            current.Add(statement);
        }

        if (current is not null)
        {
            yield return new Segment(false, current);
        }
    }

    private static IEnumerable<ImportsStatementSyntax> Sorted(
        List<ImportsStatementSyntax> segment,
        List<SyntaxTrivia> header,
        string newLine
    )
    {
        var entries = Flatten(segment, newLine).ToList();

        var ordered = entries
            .DistinctBy(e => e.Clause.ToString().Trim(), StringComparer.OrdinalIgnoreCase)
            .OrderBy(e => e.Group)
            .ThenBy(SystemRank)
            .ThenBy(e => e.SortKey, StringComparer.OrdinalIgnoreCase)
            .ToList();

        for (var i = 0; i < ordered.Count; i++)
        {
            var entry = ordered[i];
            var leading = new List<SyntaxTrivia>();

            if (i == 0)
            {
                leading.AddRange(header);
            }

            leading.AddRange(entry.Comments);

            yield return SyntaxFactory
                .ImportsStatement(
                    ImportsKeyword,
                    SyntaxFactory.SingletonSeparatedList(entry.Clause.WithoutTrivia())
                )
                .WithLeadingTrivia(leading)
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(newLine));
        }
    }

    private static IEnumerable<Entry> Flatten(
        IEnumerable<ImportsStatementSyntax> imports,
        string newLine
    )
    {
        foreach (var statement in imports)
        {
            var comments = CommentsOf(statement, newLine);
            var first = true;

            foreach (var clause in statement.ImportsClauses)
            {
                yield return new Entry(
                    clause,
                    GroupOf(clause),
                    SortKeyOf(clause),
                    first ? comments : []
                );
                first = false;
            }
        }
    }

    private static ImportGroup GroupOf(ImportsClauseSyntax clause) =>
        clause switch
        {
            SimpleImportsClauseSyntax { Alias: not null } => ImportGroup.Alias,
            XmlNamespaceImportsClauseSyntax => ImportGroup.Xml,
            _ => ImportGroup.Namespace,
        };

    private static string SortKeyOf(ImportsClauseSyntax clause) =>
        clause switch
        {
            SimpleImportsClauseSyntax { Alias: not null } simple => simple
                .Alias
                .Identifier
                .ValueText,
            SimpleImportsClauseSyntax simple => simple.Name.ToString(),
            _ => clause.ToString().Trim(),
        };

    private static int SystemRank(Entry entry)
    {
        if (entry.Group != ImportGroup.Namespace)
        {
            return 0;
        }

        var name = entry.SortKey;
        var isSystem =
            name.Equals("System", StringComparison.OrdinalIgnoreCase)
            || name.StartsWith("System.", StringComparison.OrdinalIgnoreCase);

        return isSystem ? 0 : 1;
    }

    private static List<SyntaxTrivia> ExtractFileHeader(ImportsStatementSyntax first)
    {
        var trivia = first.GetLeadingTrivia().ToList();
        var lastBlankLine = -1;

        for (var i = 0; i < trivia.Count; i++)
        {
            if (!trivia[i].IsKind(SyntaxKind.EndOfLineTrivia))
            {
                continue;
            }

            var previous = i > 0 ? trivia[i - 1] : default;
            if (
                i == 0
                || previous.IsKind(SyntaxKind.EndOfLineTrivia)
                || previous.IsKind(SyntaxKind.WhitespaceTrivia)
            )
            {
                lastBlankLine = i;
            }
        }

        return lastBlankLine < 0 ? [] : trivia[..(lastBlankLine + 1)];
    }

    private static List<SyntaxTrivia> CommentsOf(ImportsStatementSyntax statement, string newLine)
    {
        var trivia = statement.GetLeadingTrivia();
        var header = ExtractFileHeader(statement).Count;
        var comments = new List<SyntaxTrivia>();

        for (var i = header; i < trivia.Count; i++)
        {
            if (trivia[i].IsKind(SyntaxKind.CommentTrivia))
            {
                comments.Add(trivia[i]);
                comments.Add(SyntaxFactory.EndOfLine(newLine));
            }
            else if (trivia[i].IsKind(SyntaxKind.DocumentationCommentTrivia))
            {
                comments.Add(trivia[i]);

                if (!trivia[i].ToString().EndsWith('\n'))
                {
                    comments.Add(SyntaxFactory.EndOfLine(newLine));
                }
            }
        }

        return comments;
    }

    private readonly record struct Entry(
        ImportsClauseSyntax Clause,
        ImportGroup Group,
        string SortKey,
        List<SyntaxTrivia> Comments
    );
}
