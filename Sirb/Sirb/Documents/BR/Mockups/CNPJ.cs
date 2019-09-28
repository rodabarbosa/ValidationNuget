using System;
using System.Text;

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
			StringBuilder sb = new StringBuilder();
			int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[12] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3 };
			Random random = new Random();
			int total1 = 0;
			int total2 = 0;
			int value;
			for (int i = 0; i < 12; i++)
			{
				value = random.Next(10);
				sb.Append(value.ToString());
				total1 += value * multiplier1[i];
				total2 += value * multiplier2[i];
			}
			int rest = total1 % 11;
			int digit1 = rest < 2 ? 0 : 11 - rest;
			total2 += digit1 * 2;

			rest = total2 % 11;
			int digit2 = (rest < 2) ? 0 : 11 - rest;
			sb.Append(digit1)
				.Append(digit2);

			return sb.ToString();
		}
	}
}