using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Sirb.Benchmark.TestLib;
using Sirb.Documents.BR.Validation;

namespace Sirb.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class StringBenchmark
{
    private static readonly string _cpfValidWithMask = "555.608.950-75";
    private static readonly string _cpfValidWithoutMask = "55560895075";

    [Benchmark]
    public static void LibRemoveMask()
    {
        Cpf.RemoveMask(_cpfValidWithMask);
    }

    [Benchmark]
    public static void RemoveMaskWithReplace()
    {
        StringTest.RemoveMaskWithReplace(_cpfValidWithMask);
    }

    [Benchmark]
    public static void RemoveMaskWithFor()
    {
        StringTest.RemoveMaskWithFor(_cpfValidWithMask);
    }

    [Benchmark]
    public static void RemoveMaskWithRegex()
    {
        StringTest.RemoveMaskWithRegex(_cpfValidWithMask);
    }

    [Benchmark]
    public static void LibPlaceMask()
    {
        Cpf.PlaceMask(_cpfValidWithoutMask);
    }
}
