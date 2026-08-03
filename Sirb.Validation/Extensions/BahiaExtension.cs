using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class BahiaExtension
{
    public static string InscricaoEstadualMaskBa(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{6})(\d{2})", "$1-$2", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
