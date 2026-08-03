using System.Text.RegularExpressions;
using System;

namespace Sirb.Validation.Extensions;

public static class SantaCatarinaExtension
{
    public static string InscricaoEstadualMaskSc(this string value)
    {
        var cleanValue = value?.OnlyNumbers();
        return string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(cleanValue, @"(\d{3})(\d{3})(\d{3})", "$1.$2.$3", RegexOptions.None, TimeSpan.FromMilliseconds(100));
    }
}
