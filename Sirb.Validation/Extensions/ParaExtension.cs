using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class ParaExtension
    {
        public static string InscricaoEstadualMaskPa(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{6})(\d{1})", "$1-$2-$3");
        }
    }
}
