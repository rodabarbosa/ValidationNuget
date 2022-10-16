#region

using System.Text.RegularExpressions;

#endregion

namespace Sirb.Validation.Extensions
{
    public static class TocantinsExtension
    {
        public static string InscricaoEstadualMaskTo(this string value)
        {
            var cleanValue = value?.OnlyNumbers();

            return string.IsNullOrEmpty(cleanValue)
                ? default
                : Regex.Replace(cleanValue, @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");
        }
    }
}
