using System;
using System.Text;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Responsable for PIS mockup
	/// </summary>
	public static class PIS
	{
		/// <summary>
		/// Generate PIS number
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Generate()
		{
			var random = new Random();
			var sb = new StringBuilder();
			var multiplier = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			var total = 0;
			var genDigit = 0;

			for (var i = 0; i < 10; i++)
			{
				genDigit = random.Next(10);
				sb.Append(genDigit.ToString());
				total += genDigit * multiplier[i];
			}

			var rest = total % 11;
			var digit = rest < 2 ? 0 : 11 - rest;

			sb.Append(digit.ToString());
			return sb.ToString();
		}
	}
}