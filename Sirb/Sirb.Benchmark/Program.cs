using BenchmarkDotNet.Running;

namespace Sirb.Benchmark
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			BenchmarkRunner.Run<StringBenchmark>();
		}
	}
}

