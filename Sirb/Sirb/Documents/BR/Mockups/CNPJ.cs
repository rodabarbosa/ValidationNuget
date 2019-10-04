using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número CNPJ
	/// </summary>
	public static class CNPJ
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
			int totalThirteenDigit = 0;
			int totalFourteenDigit = 0;

			for (int i = 0; i < 12; i++)
			{
				generatedNambers.Add(random.Next(10));
				totalThirteenDigit += generatedNambers[generatedNambers.Count - 1] * CalculateBeforeLastDigitWeight(i);
				totalFourteenDigit += generatedNambers[generatedNambers.Count - 1] * CalculateLastDigitWeight(i);
			}

			generatedNambers.Add(GetDigitValue(totalThirteenDigit));
			totalFourteenDigit += generatedNambers[generatedNambers.Count - 1] * 2;

			generatedNambers.Add(GetDigitValue(totalFourteenDigit));

			return generatedNambers.ToArray();
		}

		private static int CalculateBeforeLastDigitWeight(int index)
		{
			int value = index < 4 ? 5 : 13;
			return value - index;
		}

		private static int CalculateLastDigitWeight(int index)
		{
			int value = index < 5 ? 6 : 14;
			return value - index;
		}

		private static int GetDigitValue(int summationValue)
		{
			int remainder = summationValue % 11;
			return remainder < 2 ? 0 : 11 - remainder;
		}
	}
}