using Sirb.Documents.BR.Rules;
using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número PIS
	/// </summary>
	public static class Pis
	{
		/// <summary>
		/// Gera número PIS
		/// </summary>
		/// <returns></returns>
		public static string Generate()
		{
			int[] generatedNumbers = GenerateNumbers();
			return generatedNumbers.ConvertToString();
		}

		private static int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int>();
			Random random = new Random();

			int total = 0;
			for (int i = 0; i < 10; i++)
			{
				generatedNumbers.Add(random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * PisRule.CalculateWeight(i);
			}

			generatedNumbers.Add(PisRule.CalculateLastDigit(total));

			return generatedNumbers.ToArray();
		}
	}
}