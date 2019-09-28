using System;
using System.Text;

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
			Random random = new Random();
			StringBuilder sb = new StringBuilder();
			int[] multiplier = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int total = 0;

			int genDigit;
			for (int i = 0; i < 10; i++)
			{
				genDigit = random.Next(10);
				sb.Append(genDigit.ToString());
				total += genDigit * multiplier[i];
			}

			int digit = GetDigit(total);

			sb.Append(digit.ToString());
			return sb.ToString();
		}

		private static int GetDigit(int value)
		{
			int rest = value % 11;
			return rest < 2 ? 0 : 11 - rest;
		}
	}
}