using System;
using System.Collections.Generic;
using System.Text;
using Sirb.Extensions;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Generated Renavam  value
	/// </summary>
	public static class Renavam
	{
		/// <summary>
		/// Gera número Renavam
		/// </summary>
		/// <returns></returns>
		public static string Generate()
		{
			int[] generatedNumbers = GenerateNumbers();
			return generatedNumbers.ConvertToString();
		}

		private static int[] GenerateNumbers()

		{
			var random = new Random();
			var listInt = new List<int>();

			int length = 10;
			for (int i = 0; i < length; i++)
				listInt.Add(random.Next(9));

			var reverseList = new List<int>();
			for (int i = length; i > 0; i--)
				reverseList.Add(listInt[i - 1]);

			int total = Rules.RenavanRules.GetSummationValue(reverseList);
			int calculatedValue = Rules.RenavanRules.CalculateastDigit(total);
			listInt.Add(calculatedValue);
			return listInt.ToArray();
		}
	}
}
