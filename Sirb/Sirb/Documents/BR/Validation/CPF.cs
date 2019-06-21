using Sirb.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// CCPF
	/// </summary>
	public static class CPF
	{
		/// <summary>
		/// Validador de CPF
		/// </summary>
		/// <param name="value">CPF</param>
		/// <returns></returns>
		public static bool IsValid(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}

			var aux = RemoveMask(value);
			var invalidNumbers = new List<string>
			{
				"00000000000",
				"11111111111",
				"22222222222",
				"33333333333",
				"44444444444",
				"55555555555",
				"66666666666",
				"77777777777",
				"88888888888",
				"99999999999",
				"01234567890"
			};

			if (aux.Length != 11 || invalidNumbers.Contains(aux))
			{
				return false;
			}

			var digit10 = int.Parse(aux.Substring(9, 1));
			var digit11 = int.Parse(aux.Substring(10));
			var sum1 = 0;
			var sum2 = 0;

			for (var i = 0; i < 9; i++)
			{
				sum1 += int.Parse(aux[i].ToString()) * (10 - i);
				sum2 += int.Parse(aux[i].ToString()) * (11 - i);
			}

			var div1 = sum1 * 10 % 11;
			if (div1 == 10)
			{
				div1 = 0;
			}

			sum2 += digit10 * 2;
			var div2 = sum2 * 10 % 11;
			if (div2 == 10)
			{
				div2 = 0;
			}

			return div1 == digit10 && div2 == digit11;
		}

		/// <summary>
		/// Remove mascara do CPF
		/// </summary>
		/// <param name="value">CPF number</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara no CPF
		/// </summary>
		/// <param name="value">CPF</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");

		/// <summary>
		/// Obtém estado emissor do CPF
		/// </summary>
		/// <param name="value">CPF</param>
		/// <exception cref="InvalidOperationException">CPF deve ser valido</exception>
		/// <returns></returns>
		public static string GetIssuingState(string value)
		{
			if (!IsValid(value))
			{
				throw new InvalidOperationException("Invalid number");
			}

			var aux = RemoveMask(value);
			switch (int.Parse(aux.Substring(8, 1)))
			{
				case 0: return "RS";
				case 1: return "DF, GO, MS, TO";
				case 2: return "AC, AP, AM, PA, RO, RR";
				case 3: return "CE, MA, PI ";
				case 4: return "PE, RN, PB, AL";
				case 5: return "BA, SE";
				case 6: return "MG";
				case 7: return "RJ, ES";
				case 8: return "SP";
				case 9: return "PR, SC";
				default: return "Unknown";
			}
		}
	}
}