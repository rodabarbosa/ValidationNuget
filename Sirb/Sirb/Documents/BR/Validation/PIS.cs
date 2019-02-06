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
			// mascara 103.28379.39/2
			var aux = RemoveMask(value);
			if (aux.Length != 11)
				return false;

			var multiplier = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			var sum = 0;
			for (var i = 0; i < 10; i++)
			{
				sum += int.Parse(aux[i].ToString()) * multiplier[i];
			}

			var div = sum % 11;
			div = (div < 2) ? 0 : (11 - div);
			return value.EndsWith(div.ToString());
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
		public static string PlaceMask(string value) => (string.IsNullOrEmpty(value)) ? null : Regex.Replace(RemoveMask(value), @"(\d{3})(\d{5})(\d{2})(\d{1})", "$1.$2.$3/$4");
	}
}