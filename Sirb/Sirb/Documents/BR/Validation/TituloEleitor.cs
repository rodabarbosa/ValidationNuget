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
			string aux = RemoveMask(value);
			if (string.IsNullOrEmpty(aux) || aux.Length != 12)
				return false;

			int digit1 = GetFirstDigit(aux);
			int digit2 = GetSecondDigit(aux);
			int stateDigit = GetStateDigit(aux);
			return IsStateDigitValid(stateDigit)
					&& aux[10].ToString().Equals(digit1.ToString())
					&& aux[11].ToString().Equals(digit2.ToString());
		}

		#region Validation

		private static int GetFirstDigit(string value)
		{
			int total = 0;
			for (int i = 0; i < 8; i++)
				total += int.Parse(value[i].ToString()) * (i + 2);

			int digit = total % 11;
			if (digit > 9)
				digit = 0;

			return digit;
		}

		private static int GetSecondDigit(string value)
		{
			int total = 0;
			for (int i = 8; i < 11; i++)
				total += int.Parse(value[i].ToString()) * (i - 1);

			int digit = total % 11;
			if (digit > 9)
				digit = 0;

			return digit;
		}

		private static int GetStateDigit(string value) => int.Parse($"{value[8].ToString()}{value[9].ToString()}");

		private static bool IsStateDigitValid(int digit) => digit > 0 && digit < 29;

		#endregion Validation

		/// <summary>
		/// Remove mascara do Titulo de Eleitor
		/// </summary>
		/// <param name="value">Titulo de Eleitor</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => string.IsNullOrEmpty(value) ? value : value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara no Título de Eleitor
		/// </summary>
		/// <param name="value">Titulo de Eleitor</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => string.IsNullOrEmpty(value) ? value : Regex.Replace(RemoveMask(value), @"(\d{4})(\d{4})(\d{4})", "$1.$2.$3");
	}
}