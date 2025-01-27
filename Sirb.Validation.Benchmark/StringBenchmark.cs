namespace Sirb.Validation.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class StringBenchmark
{
    private const string CpfValidWithMask = "555.608.950-75";
    private const string CpfValidWithoutMask = "55560895075";

    [Benchmark]
    public void LibRemoveMask()
    {
        _ = CpfValidWithMask.RemoveMask();
    }

    [Benchmark]
    public void RemoveMaskWithReplace()
    {
        StringTest.RemoveMaskWithReplace(CpfValidWithMask);
    }

    [Benchmark]
    public void RemoveMaskWithFor()
    {
        StringTest.RemoveMaskWithFor(CpfValidWithMask);
    }

    [Benchmark]
    public void RemoveMaskWithRegex()
    {
        StringTest.RemoveMaskWithRegex(CpfValidWithMask);
    }

    [Benchmark]
    public void LibPlaceMask()
    {
        _ = CpfValidation.PlaceMask(CpfValidWithoutMask);
    }
}
