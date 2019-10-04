using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número PIS
	/// </summary>
	public static class PIS
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
			int[] multiplier = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int total = 0;
			for (int i = 0; i < 10; i++)
			{
				generatedNumbers.Add(random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * multiplier[i];
			}

			generatedNumbers.Add(GetDigitValue(total));

			return generatedNumbers.ToArray();
		}

		private static int GetDigitValue(int value)
		{
			int remainder = value % 11;
			return remainder < 2 ? 0 : 11 - remainder;
		}
	}
}