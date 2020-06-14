using Sirb.Documents.BR.Rules;
using Sirb.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// PIS
	/// </summary>
	public static class Pis
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
			int lastDigit = PisRule.CalculateLastDigit(sum);
			return value.EndsWith(lastDigit.ToString());
		}

		private static int GetSum(string value)
		{
			int sum = 0;
			for (int i = 0; i < 10; i++)
				sum += int.Parse(value[i].ToString()) * PisRule.CalculateWeight(i);

			return sum;
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