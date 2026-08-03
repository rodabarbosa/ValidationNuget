using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class MaranhaoExtension
{
    public static string InscricaoEstadualMaskMa(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3/$4-$5", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
