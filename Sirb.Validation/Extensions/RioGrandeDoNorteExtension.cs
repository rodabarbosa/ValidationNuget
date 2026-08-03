using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class RioGrandeDoNorteExtension
{
    public static string InscricaoEstadualMaskRn(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        if (string.IsNullOrEmpty(cleanValue))
            return default;

        return cleanValue.Length == 9
            ? Regex.Replace(cleanValue, @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4", RegexOptions.None, TimeSpan.FromMilliseconds(100))
            : Regex.Replace(cleanValue, @"(\d{2})(\d{1})(\d{3})(\d{3})(\d{1})", "$1.$2.$3.$4-$5", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
