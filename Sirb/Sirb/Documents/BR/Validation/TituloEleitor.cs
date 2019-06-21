using Sirb.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// Título de Eleitor
	/// </summary>
	public static class TituloEleitor
	{
		/// <summary>
		/// Validador de Título de Eleitor
		/// </summary>
		/// <param name="value">Titulo de Eleitor</param>
		/// <returns></returns>
		public static bool IsValid(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}

			var aux = RemoveMask(value);
			if (aux.Length != 12)
			{
				return false;
			}

			var total = 0;
			for (var i = 0; i < 8; i++)
			{
				total += int.Parse(aux[i].ToString()) * (i + 2);
			}
			var digit1 = total % 11;
			if (digit1 > 9)
			{
				digit1 = 0;
			}

			total = 0;
			for (var i = 8; i < 11; i++)
			{
				total += int.Parse(aux[i].ToString()) * (i - 1);
			}
			var digit2 = total % 11;
			if (digit2 > 9)
			{
				digit2 = 0;
			}

			var stateDigit = int.Parse($"{aux[8].ToString()}{aux[9].ToString()}");
			return stateDigit > 0
					&& stateDigit < 29
					&& aux[10].ToString().Equals(digit1.ToString())
					&& aux[11].ToString().Equals(digit2.ToString());
		}

		/// <summary>
		/// Remove mascara do Titulo de Eleitor
		/// </summary>
		/// <param name="value">Titulo de Eleitor</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara no Título de Eleitor
		/// </summary>
		/// <param name="value">Titulo de Eleitor</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{4})(\d{4})(\d{4})", "$1.$2.$3");
	}
}