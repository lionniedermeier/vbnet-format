using System.Collections.Immutable;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Expressions;

/// <summary>
/// A query, broken between its clauses. A clause reads as one thought, so the break goes in front of
/// the keyword that opens the next one -- the only place VB continues implicitly before a token
/// rather than after it.
/// </summary>
internal static class QueryExpressionRule
{
    /// <summary>Prints <paramref name="node"/> as a run of clauses.</summary>
    public static Doc Format(QueryExpressionSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        var items = ImmutableArray.CreateBuilder<Doc>();

        foreach (var clause in node.Clauses)
        {
            if (items.Count > 0)
            {
                items.Add(context.BreakBefore(clause.GetFirstToken()));
            }

            items.Add(visitor.Format(clause));
        }

        return VbDocBuilder.Run(items.DrainToImmutable());
    }
}
