using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sirb.Extensions
{
	internal static class StringExtension
	{
		public static string OnlyNumbers(this string value) => Regex.Replace(value, @"[^\d]", string.Empty);

		public static string NoNumbers(this string value) => Regex.Replace(value, @"[\d]", string.Empty);

		public static string ToCapitalize(this string value)
		{
			if (string.IsNullOrEmpty(value))
				return value;

			string[] strings = value.Split(' ');
			StringBuilder capitalizedString = new StringBuilder();
			foreach (string item in strings)
			{
				capitalizedString.Append(item[0].ToString().ToUpper())
								.Append(item.Substring(1).ToLower())
								.Append(string.Empty);
			}

			return capitalizedString.ToString().Trim();
		}

		public static string RemoveLatinCharacters(this string value)
		{
			string decomposed = value.Normalize(NormalizationForm.FormD);
			System.Collections.Generic.IEnumerable<char> filtered = decomposed.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
			return new String(filtered.ToArray());
		}
	}
}