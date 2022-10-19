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

        public static string RemoveMask(this string value)
        {
            return value?.OnlyNumbers();
        }

        public static string NoNumbers(this string value)
        {
            return Replace(value, @"[\d]");
        }

        private static string Replace(string value, string pattern)
        {
            return Regex.Replace(value, pattern, string.Empty);
        }

        public static string ToCapitalizeAll(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static string ToCapitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var firstLetter = value.Substring(0, 1).ToUpper();
            var restOfSentence = value.Substring(1, value.Length - 1).ToLower();

            return firstLetter + restOfSentence;
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
