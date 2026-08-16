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
    // Without the space this would produce "ImportsSystem"; the statements are passed on as text and
    // therefore have to be valid already at this point.
    private static readonly SyntaxToken ImportsKeyword =
        SyntaxFactory.Token(SyntaxKind.ImportsKeyword).WithTrailingTrivia(SyntaxFactory.Space);

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

        var header = ExtractFileHeader(root.Imports[0]);
        var entries = Flatten(root.Imports).ToList();

        var ordered = entries
            .DistinctBy(e => e.Clause.ToString().Trim(), StringComparer.OrdinalIgnoreCase)
            .OrderBy(e => e.Group)
            .ThenBy(SystemRank)
            .ThenBy(e => e.SortKey, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var statements = new List<ImportsStatementSyntax>(ordered.Count);
        for (var i = 0; i < ordered.Count; i++)
        {
            var entry = ordered[i];
            var leading = new List<SyntaxTrivia>();

            if (i == 0)
            {
                leading.AddRange(header);
            }

            leading.AddRange(entry.Comments);

            statements.Add(SyntaxFactory
                .ImportsStatement(ImportsKeyword, SyntaxFactory.SingletonSeparatedList(entry.Clause.WithoutTrivia()))
                .WithLeadingTrivia(leading)
                .WithTrailingTrivia(SyntaxFactory.EndOfLine(newLine)));
        }

        return root.WithImports(SyntaxFactory.List(statements));
    }

    /// <summary>Splits <c>Imports A, B</c> into one statement per clause, so that sorting is unambiguous.</summary>
    private static IEnumerable<Entry> Flatten(SyntaxList<ImportsStatementSyntax> imports)
    {
        foreach (var statement in imports)
        {
            var comments = CommentsOf(statement);
            var first = true;

            foreach (var clause in statement.ImportsClauses)
            {
                // Comments sit above the statement and therefore belong to its first clause.
                yield return new Entry(clause, GroupOf(clause), SortKeyOf(clause), first ? comments : []);
                first = false;
            }
        }
    }

    private static ImportGroup GroupOf(ImportsClauseSyntax clause) => clause switch
    {
        SimpleImportsClauseSyntax { Alias: not null } => ImportGroup.Alias,
        XmlNamespaceImportsClauseSyntax => ImportGroup.Xml,
        _ => ImportGroup.Namespace,
    };

    private static string SortKeyOf(ImportsClauseSyntax clause) => clause switch
    {
        SimpleImportsClauseSyntax { Alias: not null } simple => simple.Alias.Identifier.ValueText,
        SimpleImportsClauseSyntax simple => simple.Name.ToString(),
        _ => clause.ToString().Trim(),
    };

    /// <summary><c>System</c> and <c>System.*</c> sort ahead of the remaining namespaces.</summary>
    private static int SystemRank(Entry entry)
    {
        if (entry.Group != ImportGroup.Namespace)
        {
            return 0;
        }

        var name = entry.SortKey;
        var isSystem = name.Equals("System", StringComparison.OrdinalIgnoreCase)
            || name.StartsWith("System.", StringComparison.OrdinalIgnoreCase);

        return isSystem ? 0 : 1;
    }

    /// <summary>
    /// Separates a file header from the comments of the first import: everything up to and including
    /// the last blank line counts as the header and stays at the top instead of travelling with the
    /// import it happened to precede.
    /// </summary>
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

            // A blank line is a line ending with no comment preceding it on the same line.
            var previous = i > 0 ? trivia[i - 1] : default;
            if (i == 0 || previous.IsKind(SyntaxKind.EndOfLineTrivia) || previous.IsKind(SyntaxKind.WhitespaceTrivia))
            {
                lastBlankLine = i;
            }
        }

        return lastBlankLine < 0 ? [] : trivia[..(lastBlankLine + 1)];
    }

    /// <summary>The comments of a statement, without the file header and without whitespace.</summary>
    private static List<SyntaxTrivia> CommentsOf(ImportsStatementSyntax statement)
    {
        var trivia = statement.GetLeadingTrivia();
        var header = ExtractFileHeader(statement).Count;
        var comments = new List<SyntaxTrivia>();

        for (var i = header; i < trivia.Count; i++)
        {
            if (trivia[i].IsKind(SyntaxKind.CommentTrivia))
            {
                comments.Add(trivia[i]);
                comments.Add(SyntaxFactory.EndOfLine(Environment.NewLine));
            }
        }

        return comments;
    }

    private readonly record struct Entry(
        ImportsClauseSyntax Clause,
        ImportGroup Group,
        string SortKey,
        List<SyntaxTrivia> Comments);
}
