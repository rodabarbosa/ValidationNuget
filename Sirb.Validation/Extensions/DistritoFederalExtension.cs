using System.Text.RegularExpressions;

namespace Sirb.Validation.Extensions
{
    public static class DistritoFederalExtension
    {
        public static string InscricaoEstadualMaskDf(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{6})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }
    }
}
