﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sirb.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string value)
        {
            return Regex.Replace(value, @"[^\d]", "");
        }

        public static string NoNumbers(this string value)
        {
            return Regex.Replace(value, @"[\d]", "");
        }

        public static string ToCapitalizeAll(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            string[] strings = value.Split(' ');
            StringBuilder capitalizedString = new StringBuilder();
            foreach (string item in strings) capitalizedString.Append(item.ToCapitalize()).Append("");

            return capitalizedString.ToString().Trim();
        }

        public static string ToCapitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            string aux = value.Trim();
            return aux[0].ToString().ToUpper() + aux.Substring(1).ToLower();
        }

        public static string RemoveLatinCharacters(this string value)
        {
            string decomposed = value.Normalize(NormalizationForm.FormD);
            IEnumerable<char> filtered = decomposed.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(filtered.ToArray());
        }

        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var sb = new StringBuilder();
            for (int i = value.Length; i > 0; i--)
                sb.Append(value[i - 1]);

            return sb.ToString();
        }
    }
}
