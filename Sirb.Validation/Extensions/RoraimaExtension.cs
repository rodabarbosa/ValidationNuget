using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class RoraimaExtension
    {
        public static string InscricaoEstadualMaskRr(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{8})(\d{1})", "$1-$2");
        }
    }
}
