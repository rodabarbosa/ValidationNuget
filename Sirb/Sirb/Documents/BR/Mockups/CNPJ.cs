using Sirb.Documents.BR.Rules;
using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número CNPJ
	/// </summary>
	public static class Cnpj
	{
		/// <summary>
		/// Gera número CNPJ
		/// </summary>
		/// <returns></returns>
		public static string Generate()
		{
			int[] generatedNumbers = GenerateNumbers();
			return generatedNumbers.ConvertToString();
		}

		private static int[] GenerateNumbers()
		{
			List<int> generatedNambers = new List<int>();
			Random random = new Random();
			int totalTBeforeLastDigit = 0;
			int totalLastDigit = 0;

			for (int i = 0; i < 12; i++)
			{
				generatedNambers.Add(random.Next(10));
				totalTBeforeLastDigit += generatedNambers[generatedNambers.Count - 1] * CnpjRule.CalculateBeforeLastDigitWeight(i);
				totalLastDigit += generatedNambers[generatedNambers.Count - 1] * CnpjRule.CalculateLastDigitWeight(i);
			}

			generatedNambers.Add(CnpjRule.CalculateDigitValue(totalTBeforeLastDigit));
			totalLastDigit += generatedNambers[generatedNambers.Count - 1] * 2;

			generatedNambers.Add(CnpjRule.CalculateDigitValue(totalLastDigit));

			return generatedNambers.ToArray();
		}
	}
}