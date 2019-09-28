using Sirb.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// CNPJ
	/// </summary>
	public static class CNPJ
	{
		/// <summary>
		/// Validador de CNPJ
		/// </summary>
		/// <param name="value">CNPJ</param>
		/// <returns></returns>
		public static bool IsValid(string value)
		{
			string aux = RemoveMask(value);

			if (!HasValidParams(aux))
				return false;

			int[] sums = GetSum(aux);

			int tenthDigit = GetModulusForDigitComparison(sums[0]);
			int elevenDigit = GetModulusForDigitComparison(sums[1]);

			string lastTwoDigits = tenthDigit.ToString() + elevenDigit.ToString();
			return aux.EndsWith(lastTwoDigits);
		}

		private static bool HasValidParams(string value)
		{
			List<string> invalidNumbers = new List<string>
			{
				"00000000000000",
				"11111111111111",
				"22222222222222",
				"33333333333333",
				"44444444444444",
				"55555555555555",
				"66666666666666",
				"77777777777777",
				"88888888888888",
				"99999999999999"
			};

			return !(string.IsNullOrEmpty(value) || value.Length != 14 || invalidNumbers.Contains(value));
		}

		private static int[] GetSum(string value)
		{
			int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] sums = new int[] { 0, 0 };

			for (int i = 0; i < 12; i++)
			{
				sums[0] += int.Parse(value[i].ToString()) * multiplier1[i];
				sums[1] += int.Parse(value[i].ToString()) * multiplier2[i];
			}
			sums[1] += int.Parse(value[12].ToString()) * multiplier2[12];

			return sums;
		}

		private static int GetModulusForDigitComparison(int value)
		{
			int modulus = value % 11;
			return (modulus < 2) ? 0 : (11 - modulus);
		}

		/// <summary>
		/// Remove mascara do CNPJ
		/// </summary>
		/// <param name="value">CNPJ</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => string.IsNullOrEmpty(value) ? value : value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara ao CNPJ
		/// </summary>
		/// <param name="value">CNPJ number</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
	}
}