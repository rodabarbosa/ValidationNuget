using System;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class SaoPauloExtension
    {
        public static string InscricaoEstadualMaskSp(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            if (string.IsNullOrEmpty(cleanValue))
                return default;

            return value.StartsWith("P", StringComparison.OrdinalIgnoreCase)
                ? Regex.Replace(cleanValue, @"(\d{8})(\d{1})(\d{3})", "P-$1.$2/$3")
                : Regex.Replace(cleanValue, @"(\d{3})(\d{3})(\d{3})(\d{3})", "$1.$2.$3.$4");
        }
    }
}
