using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class RondoniaExtension
    {
        public static string InscricaoEstadualMaskRo(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{5})(\d{1})", "$1.$2-$3");
        }
    }
}
