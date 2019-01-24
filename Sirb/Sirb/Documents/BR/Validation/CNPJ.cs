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
			if (string.IsNullOrEmpty(value))
				return false;

			var aux = RemoveMask(value);
			var invalidNumbers = new List<string>
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

			if (aux.Length != 14 || invalidNumbers.Contains(aux))
				return false;

			int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

			string tempCnpj = aux.Substring(0, 12);

			var sum1 = 0;
			var sum2 = 0;
			for (int i = 0; i < 12; i++)
			{
				sum1 += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
				sum2 += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
			}

			var div = sum1 % 11;
			div = (div < 2) ? 0 : (11 - div);

			var digit = div.ToString();
			tempCnpj += digit;

			sum2 += int.Parse(tempCnpj[12].ToString()) * multiplier2[12];
			div = sum2 % 11;
			div = (div < 2) ? 0 : (11 - div);

			digit += div.ToString();
			return aux.EndsWith(digit);
		}

		/// <summary>
		/// Remove mascara do CNPJ
		/// </summary>
		/// <param name="value">CNPJ</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara ao CNPJ
		/// </summary>
		/// <param name="value">CNPJ number</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
	}
}