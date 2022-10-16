using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class AmapaExtension
    {
        public static string InscricaoEstadualMaskAp(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{6})(\d{1})", "$1.$2-$3");
        }
    }
}
