using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Tests;

public sealed class VbFormatterTests
{
    /// <summary>Set <c>VBNET_FORMAT_UPDATE_GOLDEN=1</c> to rewrite the expectation files.</summary>
    private static bool UpdateGolden =>
        Environment.GetEnvironmentVariable("VBNET_FORMAT_UPDATE_GOLDEN") == "1";

    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void FormatsAsExpected(string name)
    {
        var result = VbFormatter.Format(TestCases.ReadInput(name));
        Assert.False(result.HasErrors, string.Join("; ", result.Diagnostics));

        var path = TestCases.ExpectedPath(name);
        if (UpdateGolden)
        {
            File.WriteAllText(path, result.Text);
            return;
        }

        Assert.Equal(File.ReadAllText(path), result.Text);
    }

    /// <summary>
    /// A line may end before a closing bracket, so a block argument can have the bracket below it.
    /// This is the assumption the block-argument layout rests on -- asserted on the parser, not on
    /// the formatter.
    /// </summary>
    [Fact]
    public void AcceptsABreakBeforeTheBracket()
    {
        const string Source = """
            Module M

                Public Sub S()
                    Register(
                        Function(tag)
                            Return tag.Length
                        End Function
                    )
                    Handlers = {
                        Sub()
                            Work()
                        End Sub
                    }
                End Sub

            End Module

            """;

        var result = VbFormatter.Format(Source.ReplaceLineEndings("\r\n"));

        Assert.False(result.HasErrors, string.Join("; ", result.Diagnostics));
    }

    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void IsIdempotent(string name)
    {
        var once = VbFormatter.Format(TestCases.ReadInput(name)).Text;
        var twice = VbFormatter.Format(once);

        Assert.Equal(once, twice.Text);
        Assert.False(twice.Changed);
    }

    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void DoesNotChangeTheCode(string name)
    {
        var input = TestCases.ReadInput(name);
        var result = VbFormatter.Format(input);

        var before = Parse(input);
        var after = Parse(result.Text);

        // Imports are resorted and deduplicated, so compare them as a set.
        Assert.Equal(ImportClauses(before), ImportClauses(after));
        Assert.True(before.WithImports(default).IsEquivalentTo(after.WithImports(default), topLevel: false));
    }

    [Fact]
    public void LeavesAlreadyFormattedSourceUnchanged()
    {
        var input = TestCases.ReadInput("AlreadyFormatted");
        var result = VbFormatter.Format(input);

        Assert.False(result.Changed);
        Assert.Equal(input, result.Text);
    }

    [Fact]
    public void KeepsTheFileHeaderOnTop()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("FileHeader"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Equal("' Copyright (c) Contoso AG.", lines[0]);
        Assert.Equal("' Licensed under the MIT license.", lines[1]);
    }

    [Fact]
    public void SortsImportsAndRemovesDuplicates()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("UnsortedImports"));
        var imports = Parse(result.Text).Imports.Select(i => i.ToString().Trim()).ToList();

        Assert.Equal(
            [
                "Imports System",
                "Imports System.Collections.Generic",
                "Imports System.Text",
                "Imports Newtonsoft.Json",
                "Imports IO = System.IO",
            ],
            imports);
    }

    [Fact]
    public void LeavesImportsAloneWhenDisabled()
    {
        var input = TestCases.ReadInput("UnsortedImports");
        var result = VbFormatter.Format(input, new FormatterOptions { OrganizeImports = false });

        Assert.Equal("Imports System.Text", Parse(result.Text).Imports[0].ToString().Trim());
    }

    /// <summary>Proves that the indentation actually comes from <see cref="FormatterOptions"/>.</summary>
    [Fact]
    public void HonorsTheIndentWidth()
    {
        const string Source = """
            Module M
            Sub S()
            Dim x = 1
            End Sub
            End Module
            """;

        var result = VbFormatter.Format(Source, new FormatterOptions { IndentSize = 2 });
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Equal("  Sub S()", lines[1]);
        Assert.Equal("    Dim x = 1", lines[2]);
    }

    /// <summary>
    /// <see cref="EndOfLine.Auto"/> follows the input; the other two say what they mean, whatever the
    /// input used.
    /// </summary>
    [Theory]
    [InlineData(EndOfLine.Auto, "\n", "\n")]
    [InlineData(EndOfLine.Auto, "\r\n", "\r\n")]
    [InlineData(EndOfLine.Lf, "\r\n", "\n")]
    [InlineData(EndOfLine.CrLf, "\n", "\r\n")]
    public void WritesTheRequestedLineEnding(EndOfLine endOfLine, string input, string expected)
    {
        var source = string.Join(input, "Module M", "", "    Sub S()", "    End Sub", "", "End Module", "");

        var result = VbFormatter.Format(source, new FormatterOptions { EndOfLine = endOfLine });

        Assert.False(result.HasErrors, string.Join("; ", result.Diagnostics));
        Assert.Equal(expected, result.Text.Contains("\r\n", StringComparison.Ordinal) ? "\r\n" : "\n");
    }

    [Fact]
    public void DoesNotTouchUnparsableSource()
    {
        const string Broken = "Module M\r\nSub S(\r\nEnd Module\r\n";

        var result = VbFormatter.Format(Broken);

        Assert.True(result.HasErrors);
        Assert.False(result.Changed);
        Assert.Equal(Broken, result.Text);
    }

    /// <summary>
    /// Every break is an implicit continuation, so no underscore may ever be emitted -- the explicit
    /// <c>_</c> is not something vbnet-format writes at all.
    /// </summary>
    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void EmitsNoUnderscore(string name)
    {
        var result = VbFormatter.Format(TestCases.ReadInput(name));

        Assert.DoesNotContain(
            result.Text.ReplaceLineEndings("\n").Split('\n'),
            l => l.TrimEnd().EndsWith(" _", StringComparison.Ordinal));
    }

    [Fact]
    public void BreaksCallChainsAfterTheDot()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("MemberChain"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        // Plain property hops stay together; only the invoked links break.
        Assert.Equal("        Dim companies = State.Companies.Values.", lines[3]);
        Assert.Equal("            Where(AddressOf FilterDivision).", lines[4]);
    }

    /// <summary>
    /// A block argument cannot be laid out behind the bracket that holds it: its body would start
    /// one level further in than the bracket's own indent, leaving it that much less width. It goes
    /// below the bracket instead, one indent level in.
    /// </summary>
    [Fact]
    public void PlacesABlockBelowTheBracket()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LambdaArgument"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var open = Array.FindIndex(lines, l => l.TrimEnd().EndsWith("Any(", StringComparison.Ordinal));
        Assert.True(open >= 0);

        var indent = lines[open][..(lines[open].Length - lines[open].TrimStart().Length)];
        Assert.Equal(indent + "    Function(tag)", lines[open + 1]);
    }

    /// <summary>
    /// The whole point of moving the block below the bracket: its own argument lists get their width
    /// back and no longer have to break themselves.
    /// </summary>
    [Fact]
    public void KeepsABlocksBodyWithinTheLimit()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LambdaArgument"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.DoesNotContain(lines, l => l.Trim() == "\"F\",");
    }

    /// <summary>The closing bracket goes back to the list's own indent, below the block.</summary>
    [Fact]
    public void ClosesTheBracketAfterABlockOnItsOwnLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LambdaArgument"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var open = Array.FindIndex(lines, l => l.TrimEnd().EndsWith("Any(", StringComparison.Ordinal));
        var close = Array.FindIndex(lines, l => l.Trim() == "))");
        Assert.True(open >= 0 && close >= 0);

        var openIndent = lines[open][..(lines[open].Length - lines[open].TrimStart().Length)];
        var closeIndent = lines[close][..(lines[close].Length - lines[close].TrimStart().Length)];
        Assert.Equal(openIndent, closeIndent);
    }

    /// <summary>A collection initializer's brace gets the same closing-on-its-own-line treatment.</summary>
    [Fact]
    public void PlacesAnInitializersBraceOnItsOwnLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LambdaArgument"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.Trim() == "}");
    }

    /// <summary>
    /// Every list that breaks closes on a line of its own, not only one holding a block. This is the
    /// shape <c>docs/standard_format.md</c> specifies, and it is not a per-construct decision.
    /// </summary>
    [Fact]
    public void ClosesEveryBrokenListOnItsOwnLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LongArgumentList"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.Trim() == ")");

        // And at the indent of the line that opened it, not the elements'.
        var open = Array.FindIndex(lines, l => l.TrimEnd().EndsWith("String.Format(", StringComparison.Ordinal));
        var close = Array.FindIndex(lines, open, lines.Length - open, l => l.Trim() == ")");
        Assert.True(open >= 0 && close > open);
        Assert.Equal(Indent(lines[open]), Indent(lines[close]));
    }

    /// <summary>
    /// A Sub lambda gets its header on its own line, exactly like a Function lambda. It used to be
    /// excluded because the move tripped a Roslyn equivalence quirk; that no longer reproduces, so
    /// the layout now matches the lambda example in <c>docs/standard_format.md</c>.
    /// </summary>
    [Fact]
    public void PlacesASubBlockBelowTheBracketToo()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LambdaArgument"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.False(result.HasErrors, string.Join("; ", result.Diagnostics));
        Assert.DoesNotContain(lines, l => l.TrimEnd().EndsWith("Register(Sub()", StringComparison.Ordinal));
        Assert.Contains(lines, l => l.Trim() == "Sub()");
    }

    /// <summary>
    /// A list that breaks first tries every element on one indented line, and only stacks them when
    /// that line does not fit either.
    /// </summary>
    [Fact]
    public void PacksACallOntoOneIndentedLineBeforeStackingIt()
    {
        const string Source = """
            Module M

                Public Sub S()
                    SaveTankMeasurementRecord(tankIdentifierValue, currentVolumeReading, recordedTimestampUtc, auditTrailReference, operatorDisplayName)
                    SaveTankMeasurementRecord(tankIdentifierValue, currentVolumeReading, recordedTimestampUtc, auditTrailReference, operatorDisplayName, siteIdentifierValue, calibrationOffsetValue)
                End Sub

            End Module

            """;

        var lines = VbFormatter.Format(Source.ReplaceLineEndings("\r\n"))
            .Text.ReplaceLineEndings("\n").Split('\n');

        // Too wide to stay on the statement's line, but the arguments still fit on one indented
        // line of their own -- so they take it rather than stacking.
        Assert.Contains(
            lines,
            l => l.Trim() == "tankIdentifierValue, currentVolumeReading, recordedTimestampUtc, "
                + "auditTrailReference, operatorDisplayName");

        // Two more arguments and that line no longer fits either: one element per line.
        Assert.Contains(lines, l => l.Trim() == "operatorDisplayName,");
        Assert.Contains(lines, l => l.Trim() == "calibrationOffsetValue");
    }

    /// <summary>
    /// The packed layout is for signatures and calls only. A list of named things -- an initializer,
    /// a type parameter list -- always stacks, so that adding one is a one-line diff.
    /// </summary>
    [Fact]
    public void NeverPacksAnInitializer()
    {
        const string Source = """
            Module M

                Public Sub S()
                    Dim tank = New Tank With {.Identifier = 1, .CurrentVolume = 240.5, .Label = "the primary tank"}
                End Sub

            End Module

            """;

        var lines = VbFormatter.Format(Source.ReplaceLineEndings("\r\n"), new FormatterOptions { MaxLineLength = 60 })
            .Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.Trim() == ".Identifier = 1,");
        Assert.Contains(lines, l => l.Trim() == ".CurrentVolume = 240.5,");
        Assert.Contains(lines, l => l.Trim() == "}");
    }

    /// <summary>The leading dot of a With block needs an underscore, so it must stay put.</summary>
    [Fact]
    public void LeavesTheLeadingDotOfAWithBlockInPlace()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("WithBlock"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.TrimStart().StartsWith(".Diagnostics", StringComparison.Ordinal));
        Assert.DoesNotContain(lines, l => l.TrimEnd().EndsWith("With configuration.", StringComparison.Ordinal));
    }

    /// <summary>
    /// A comma outranks an operator: the condition of the ternary stays whole and the outer
    /// <c>If</c>'s commas break, rather than the line being split at the <c>&gt;</c>.
    /// </summary>
    [Fact]
    public void PrefersBreakingAtTheCommaOverTheOperator()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("NestedTernary"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        // No line may end at a comparison operator.
        Assert.DoesNotContain(lines, l => l.TrimEnd().EndsWith(">", StringComparison.Ordinal));
    }

    /// <summary>
    /// The outer list breaks before the nested one: the line holding the head of a nested ternary
    /// ends at the opening paren of the trailing <c>If</c>, not partway into its arguments.
    /// </summary>
    [Fact]
    public void BreaksTheOuterListBeforeTheInner()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("NestedTernary"));

        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');
        var head = Array.Find(lines, l => l.Contains("Dim nestedConditional"));

        Assert.NotNull(head);
        Assert.EndsWith("If(", head!.TrimEnd());
    }

    /// <summary>
    /// The clauses of a query align under the keyword that opens it rather than hanging below the
    /// statement, which is what the VB style guide asks for.
    /// </summary>
    [Fact]
    public void AlignsQueryClausesUnderTheHead()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("XmlLiteralInline"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var head = Array.FindIndex(lines, l => l.Contains("<%= From e In _employees", StringComparison.Ordinal));
        Assert.True(head >= 0);

        var column = lines[head].IndexOf("From", StringComparison.Ordinal);
        Assert.Equal(new string(' ', column) + "Select", lines[head + 1][..(column + 6)]);
    }

    /// <summary>
    /// A join too long for its line breaks in front of <c>On</c>, which is the one keyword inside a
    /// query clause that a break is offered at.
    /// </summary>
    [Fact]
    public void BreaksAJoinBeforeItsCondition()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LinqQueryClauses"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var condition = Array.FindIndex(
            lines,
            l => l.TrimStart().StartsWith("On employee.ReportingManagerIdentifier", StringComparison.Ordinal));

        Assert.True(condition > 0);
        Assert.EndsWith("Join reportingManager In employees", lines[condition - 1]);
    }

    /// <summary>A join short enough for its line keeps its condition behind it.</summary>
    [Fact]
    public void LeavesAFittingJoinOnOneLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LinqQueryClauses"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(
            lines,
            l => l.TrimStart().StartsWith(
                "Join department In departments On employee.DepartmentId",
                StringComparison.Ordinal));
    }

    /// <summary>A query breaks in front of its clause keywords, and needs no underscore for it.</summary>
    [Fact]
    public void BreaksAQueryBeforeTheClause()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LinqQuery"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.TrimStart().StartsWith("Where employee.Salary", StringComparison.Ordinal));
        Assert.Contains(lines, l => l.TrimStart().StartsWith("Order By employee.Salary", StringComparison.Ordinal));
    }

    [Fact]
    public void KeepsAFittingQueryOnTheStatementLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LinqQuery"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(lines, l => l.Trim() == "Dim names = From employee In employees Select employee.Name");
    }

    [Fact]
    public void HangsALongQueryBelowTheAssignment()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("LinqQuery"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var head = Array.FindIndex(
            lines,
            l => l.Contains("Dim quarterlyHeadcountByDepartment", StringComparison.Ordinal));

        Assert.True(head >= 0);
        Assert.EndsWith("=", lines[head]);

        var query = lines[head + 1].TrimStart();
        Assert.StartsWith("From employee In employees Where", query, StringComparison.Ordinal);
        Assert.Contains("Select employee.Name", query, StringComparison.Ordinal);
    }

    /// <summary>
    /// A parameter's attribute is not a declaration's: it sits inside a bracketed list, where a line
    /// of its own would only be a worse layout.
    /// </summary>
    [Fact]
    public void LeavesAParameterAttributeOnItsLine()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("Attributes"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        Assert.Contains(
            lines,
            l => l.TrimStart().StartsWith("Public Sub Write(<Out> ByRef count", StringComparison.Ordinal));
    }

    /// <summary>
    /// Breaking behind the opening bracket would leave it alone on a line and buy nothing; the
    /// commas inside the list are what carries the break.
    /// </summary>
    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void LeavesTheBracketOfAnAttributeListNotAlone(string name)
    {
        var result = VbFormatter.Format(TestCases.ReadInput(name));

        Assert.DoesNotContain(
            result.Text.ReplaceLineEndings("\n").Split('\n'),
            l => l.TrimEnd().EndsWith("<", StringComparison.Ordinal));
    }

    /// <summary>
    /// The attributes of a tag align under the first one. vbnet-format aligns rather than indents only
    /// where what is aligned under is stable -- a tag name, a query head -- and it is not configurable;
    /// see <c>docs/standard_format.md</c>.
    /// </summary>
    [Fact]
    public void AlignsXmlAttributesUnderTheFirst()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("XmlLiteralAttributes"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        var head = Array.FindIndex(lines, l => l.Contains("<employee id=", StringComparison.Ordinal));
        Assert.True(head >= 0);

        var column = lines[head].IndexOf("id=", StringComparison.Ordinal);
        Assert.Equal(new string(' ', column) + "name=", lines[head + 1][..(column + 5)]);
    }

    /// <summary>
    /// Text content makes the whitespace around it the author's. The element carrying it keeps every
    /// character, even while the elements around it are laid out afresh.
    /// </summary>
    [Fact]
    public void DoesNotTouchTextContent()
    {
        var result = VbFormatter.Format(TestCases.ReadInput("XmlLiteralText"));
        var lines = result.Text.ReplaceLineEndings("\n").Split('\n');

        // The prose keeps its one line, the mixed content its own indentation.
        Assert.Contains(lines, l => l.Contains("<body>A paragraph with plenty of text"));
        Assert.Contains(lines, l => l == "                   Hello <%= name %>, glad you could make it.");
        Assert.Contains(lines, l => l == "   and    one   more</pre>");
    }

    private static int Indent(string line) => line.Length - line.TrimStart().Length;

    private static CompilationUnitSyntax Parse(string source) =>
        (CompilationUnitSyntax)VisualBasicSyntaxTree.ParseText(source).GetRoot();

    private static List<string> ImportClauses(CompilationUnitSyntax root) =>
        root.Imports
            .SelectMany(i => i.ImportsClauses)
            .Select(c => c.ToString().Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Order(StringComparer.OrdinalIgnoreCase)
            .ToList();
}
