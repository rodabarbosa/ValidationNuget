using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class AmazonasExtension
{
    public static string InscricaoEstadualMaskAm(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
