using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class PernambucoExtension
    {
        public static string InscricaoEstadualMaskPe(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{7})(\d{2})", "$1-$2");
        }
    }
}
