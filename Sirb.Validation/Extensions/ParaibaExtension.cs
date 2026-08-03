using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class ParaibaExtension
{
    public static string InscricaoEstadualMaskPb(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{8})(\d{1})", "$1-$2", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
