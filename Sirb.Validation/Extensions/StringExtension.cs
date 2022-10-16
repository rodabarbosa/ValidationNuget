using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string value)
        {
            return Replace(value, @"[^\d]");
        }

        public static string NoNumbers(this string value)
        {
            return Replace(value, @"[\d]");
        }

        private static string Replace(string value, string pattern)
        {
            return Regex.Replace(value, pattern, string.Empty);
        }

        public static string ToTitleCase(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static string ToCapitalizeAll(this string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return value;

            var result = new StringBuilder(value.Length);
            result.Append(value[0].ToString().ToUpper());
            for (var i = 1; i < value.Length; i++)
            {
                var letter = value[i].ToString();
                if (value[i - 1] == ' ')
                    letter = letter.ToUpper();

                result.Append(letter);
            }

            return result.ToString();
        }

        public static string ToCapitalize(this string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return value;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public static string RemoveLatinCharacters(this string value)
        {
            var decomposed = value.Normalize(NormalizationForm.FormD);
            var filtered = decomposed.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(filtered.ToArray());
        }

        public static string Reverse(this string value)
        {
            var charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
