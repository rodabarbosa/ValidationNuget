using BenchmarkDotNet.Running;

namespace Sirb.Benchmark;

internal static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<StringBenchmark>();
    }
}
