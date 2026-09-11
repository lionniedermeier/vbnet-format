using BenchmarkDotNet.Running;
using VisualBasicFormatter.Bench;

BenchmarkSwitcher.FromAssembly(typeof(FormatterBenchmarks).Assembly).Run(args);
