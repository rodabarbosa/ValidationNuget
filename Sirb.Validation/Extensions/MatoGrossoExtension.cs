using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class MatoGrossoExtension
{
    public static string InscricaoEstadualMaskMt(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{10})(\d{1})", "$1-$2", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
