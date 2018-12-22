using System;
using System.Text;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Creates CNPJ Mockup
	/// </summary>
	public static class CNPJ
	{
		/// <summary>
		/// Generate CNPJ number
		/// </summary>
		/// <returns></returns>
		public static string Generate()
		{
			var sb = new StringBuilder();
			var multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			var multiplier2 = new int[12] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3 };
			var random = new Random();
			var total1 = 0;
			var total2 = 0;
			var value = 0;
			for (var i = 0; i < 12; i++)
			{
				value = random.Next(10);
				sb.Append(value.ToString());
				total1 += value * multiplier1[i];
				total2 += value * multiplier2[i];
			}
			var rest = total1 % 11;
			var digit1 = rest < 2 ? 0 : 11 - rest;
			total2 += digit1 * 2;

			rest = total2 % 11;
			var digit2 = (rest < 2) ? 0 : 11 - rest;
			sb.Append($"{digit1}{digit2}");

			return sb.ToString();
		}
	}
}