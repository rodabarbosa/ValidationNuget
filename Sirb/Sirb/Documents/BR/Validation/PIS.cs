using Sirb.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// PIS
	/// </summary>
	public static class PIS
	{
		/// <summary>
		/// Validador de PIS
		/// </summary>
		/// <param name="value">PIS</param>
		/// <returns></returns>
		public static bool IsValid(string value)
		{
			string aux = RemoveMask(value);
			if (string.IsNullOrEmpty(aux) || aux.Length != 11)
				return false;

			int sum = GetSum(aux);
			int div = GetDigit(sum);
			return value.EndsWith(div.ToString());
		}

		private static int GetSum(string value)
		{
			int[] multiplier = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int sum = 0;
			for (int i = 0; i < 10; i++)
				sum += int.Parse(value[i].ToString()) * multiplier[i];

			return sum;
		}

		private static int GetDigit(int sum)
		{
			int div = sum % 11;
			return (div < 2) ? 0 : (11 - div);
		}

		/// <summary>
		/// Remove mascara do PIS
		/// </summary>
		/// <param name="value">PIS</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara no PIS
		/// </summary>
		/// <param name="value">PIS</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{3})(\d{5})(\d{2})(\d{1})", "$1.$2.$3/$4");
	}
}