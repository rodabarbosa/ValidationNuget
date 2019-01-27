using Sirb.Documents.BR.Enumeration;
using System;
using System.Text;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número CPF
	/// </summary>
	public static class CPF
	{
		/// <summary>
		/// Gera número CPF
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Generate(State? value = null)
		{
			var random = new Random();
			var sb = new StringBuilder();
			var total1 = 0;
			var total2 = 0;
			if (value == null)
			{
				value = (State)random.Next(10);
			}

			int genDigit;
			for (var i = 0; i < 9; i++)
			{
				genDigit = i < 8 ? random.Next(10) : (int)value.Value;
				sb.Append(genDigit.ToString());
				total1 += genDigit * (10 - i);
				total2 += genDigit * (11 - i);
			}

			var rest = total1 % 11;
			var digit1 = rest < 2 ? 0 : 11 - rest;

			total2 += digit1 * 2;
			rest = total2 % 11;
			var digit2 = (rest < 2) ? 0 : 11 - rest;
			sb.Append(digit1)
				.Append(digit2);
			return sb.ToString();
		}
	}
}