﻿using Sirb.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// Manipulate PIS document
	/// </summary>
	public static class PIS
	{
		/// <summary>
		/// Validate PIS number
		/// </summary>
		/// <param name="value">PIS number</param>
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
		/// Remove mask from PIS number
		/// </summary>
		/// <param name="value">PIS number</param>
		/// <returns></returns>
		public static string RemoveMask(string value) => value.OnlyNumbers();

		/// <summary>
		/// Place mask to PIS number
		/// </summary>
		/// <param name="value">PIS number</param>
		/// <returns></returns>
		public static string PlaceMask(string value) => (string.IsNullOrEmpty(value)) ? value : Regex.Replace(RemoveMask(value), @"(\d{3})(\d{5})(\d{2})(\d{2})", "$1.$2.$3/$4");
	}
}