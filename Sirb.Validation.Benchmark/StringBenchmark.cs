using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Sirb.Validation.Benchmark.TestLib;
using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class StringBenchmark
    {
        private const string _cpfValidWithMask = "555.608.950-75";
        private const string _cpfValidWithoutMask = "55560895075";

        [Benchmark]
        public void LibRemoveMask()
        {
            _ = CpfValidation.RemoveMask(_cpfValidWithMask);
        }

        [Benchmark]
        public void RemoveMaskWithReplace()
        {
            StringTest.RemoveMaskWithReplace(_cpfValidWithMask);
        }

        [Benchmark]
        public void RemoveMaskWithFor()
        {
            StringTest.RemoveMaskWithFor(_cpfValidWithMask);
        }

        [Benchmark]
        public void RemoveMaskWithRegex()
        {
            StringTest.RemoveMaskWithRegex(_cpfValidWithMask);
        }

        [Benchmark]
        public void LibPlaceMask()
        {
            _ = CpfValidation.PlaceMask(_cpfValidWithoutMask);
        }
    }
}