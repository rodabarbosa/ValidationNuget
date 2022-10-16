using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class ParanaExtension
    {
        public static string InscricaoEstadualMaskPr(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{8})(\d{2})", "$1-$2");
        }
    }
}
