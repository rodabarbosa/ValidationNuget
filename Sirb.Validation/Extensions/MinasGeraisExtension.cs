using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class MinasGeraisExtension
{
    public static string InscricaoEstadualMaskMg(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{3})(\d{3})(\d{3})(\d{4})", "$1.$2.$3/$4", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
