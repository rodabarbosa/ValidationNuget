using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class AmazonasExtension
    {
        public static string InscricaoEstadualMaskAm(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }
    }
}
