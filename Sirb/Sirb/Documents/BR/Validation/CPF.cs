using Sirb.Documents.BR.Rules;
using Sirb.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// CCPF
	/// </summary>
	public static class Cpf
	{
		/// <summary>
		/// Validador de CPF
		/// </summary>
		/// <param name="value">CPF</param>
		/// <returns></returns>
		public static bool IsValid(string value)
		{
			string onlyNumbersValue = RemoveMask(value);
			if (!HasValidParams(onlyNumbersValue))
				return false;

			int tenthDigit = GetTenthDigit(onlyNumbersValue);
			int eleventh = GetEleventhDigit(onlyNumbersValue);
			int[] sums = GetSum(onlyNumbersValue);

			int tenthDigitComparison = GetModulusForDigitComparison(sums[0]);
			int eleventhDigitComparison = GetModulusForDigitComparison(sums[1]);

			return tenthDigitComparison == tenthDigit && eleventhDigitComparison == eleventh;
		}

		#region Validation

		private static bool HasValidParams(string value)
		{
			List<string> invalidNumbers = new List<string>
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
				"99999999999"
				//"01234567890"
			};

			return !(string.IsNullOrEmpty(value) || value.Length != 11 || invalidNumbers.Contains(value));
		}

		private static int GetTenthDigit(string onlyNumbersValue) => int.Parse(onlyNumbersValue.Substring(9, 1));

		private static int GetEleventhDigit(string onlyNumbersValue) => int.Parse(onlyNumbersValue.Substring(10));

		private static int GetModulusForDigitComparison(int summationValue)
		{
			int value = summationValue * 10 % 11;
			if (value == 10)
				value = 0;

			return value;
		}

		private static int[] GetSum(string onlyNumbersValue)
		{
			int[] sums = new int[] { 0, 0 };
			int value;
			for (int i = 0; i < 9; i++)
			{
				value = int.Parse(onlyNumbersValue[i].ToString());
				sums[0] += value * CpfRule.CalculateBeforeLastDigitWeight(i);
				sums[1] += value * CpfRule.CalculateLastDigitWeight(i);
			}

			sums[1] += GetTenthDigit(onlyNumbersValue) * 2;

			return sums;
		}

		#endregion Validation

		/// <summary>
		/// Remove mascara do CPF
		/// </summary>
		/// <param name="value">CPF number</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => string.IsNullOrEmpty(value) ? value : value.OnlyNumbers();

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
				throw new InvalidOperationException("Invalid number");

			string aux = RemoveMask(value);
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