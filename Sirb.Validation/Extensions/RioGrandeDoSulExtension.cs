using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class RioGrandeDoSulExtension
    {
        public static string InscricaoEstadualMaskRs(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{3})(\d{7})", "$1/$2");
        }
    }
}
