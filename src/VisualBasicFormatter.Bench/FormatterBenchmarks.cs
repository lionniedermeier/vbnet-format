using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Bench;

/// <summary>
/// The pipeline stages measured as separate budgets, so a change can be attributed to the stage it
/// touched. <c>Large</c> is a wide, shallow file; <c>DeepExpression</c> is where a per-node subtree
/// walk turns quadratic.
/// </summary>
[MemoryDiagnoser]
public class FormatterBenchmarks
{
    [Params("Large", "DeepExpression")]
    public string Sample { get; set; } = "Large";

    private string _source = "";
    private FormatterOptions _options = new();
    private string _newLine = "\n";
    private VisualBasicParseOptions _parseOptions = new();
    private CompilationUnitSyntax _root = null!;
    private Doc _doc = null!;
    private PrintOptions _printOptions = null!;

    [GlobalSetup]
    public void Setup()
    {
        _source = Samples.Load(Sample);
        _options = new FormatterOptions();
        _newLine = VbFormatter.DetectNewLine(_source);
        _parseOptions = new VisualBasicParseOptions(_options.LanguageVersion);

        _root = (CompilationUnitSyntax)
            VisualBasicSyntaxTree.ParseText(_source, _parseOptions).GetRoot();

        var context = new FormatContext(_options, _root, _newLine);
        _doc = new VbDocVisitor(context).FormatRoot(_root);
        _printOptions = context.PrintOptions;
    }

    [Benchmark]
    public string Format() => VbFormatter.Format(_source, _options).Text;

    [Benchmark]
    public object Parse() =>
        VisualBasicSyntaxTree.ParseText(_source, _parseOptions).GetRoot();

    [Benchmark]
    public object BuildDoc()
    {
        var context = new FormatContext(_options, _root, _newLine);
        return new VbDocVisitor(context).FormatRoot(_root);
    }

    [Benchmark]
    public string Print() => DocPrinter.Print(_doc, _printOptions);

    [Benchmark]
    public bool Verify()
    {
        var reparsed = (CompilationUnitSyntax)
            VisualBasicSyntaxTree.ParseText(_source, _parseOptions).GetRoot();
        return _root.WithImports(default).IsEquivalentTo(reparsed.WithImports(default));
    }
}
