using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Sirb.Benchmark.TestLib;
using Sirb.Documents.BR.Validation;

namespace Sirb.Benchmark
{
	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class StringBenchmark
	{
		private static string _cpfValidWithMask = "555.608.950-75";
		private static string _cpfValidNoMask = "55560895075";

		//[Benchmark]
		//public void LibValidation() => Cpf.IsValid(_cpfValidWithMask);

		[Benchmark]
		public void LibRemoveMask() => Cpf.RemoveMask(_cpfValidWithMask);

		[Benchmark]
		public void RemoveMaskWithReplace() => StringTest.RemoveMaskWithReplace(_cpfValidWithMask);

		[Benchmark]
		public void RemoveMaskWithFor() => StringTest.RemoveMaskWithFor(_cpfValidWithMask);

		//[Benchmark]
		//public void LibPlaceMask() => Cpf.PlaceMask(_cpfValidNoMask);
	}
}