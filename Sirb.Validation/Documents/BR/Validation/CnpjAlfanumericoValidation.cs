using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Documents.BR.Validation;

/// <summary>
/// CNPJ Alfanumérico validation (new RFB format per IN RFB 2.229/2024).
/// Supports alphanumeric characters (A-Z, 0-9) in the first 12 positions,
/// with 2 numeric check digits. Retrocompatible with legacy numeric CNPJ.
/// </summary>
public static class CnpjAlfanumericoValidation
{
    private static readonly Regex CnpjMaskRegex = new(@"[./-]", RegexOptions.Compiled);

    /// <summary>
    /// Validates an alphanumeric CNPJ (14 characters: 12 alphanumeric + 2 numeric check digits).
    /// Accepts legacy numeric CNPJ for retrocompatibility.
    /// </summary>
    /// <param name="value">CNPJ value (with or without mask).</param>
    /// <returns>True if valid, false otherwise.</returns>
    public static bool IsValid(string value)
    {
        var normalized = RemoveCnpjMask(value);

        if (!HasValidParams(normalized))
            return false;

        var sums = GetSum(normalized);

        var beforeLastDigit = CnpjAlfanumericoRule.CalculateDigitValue(sums[0]);
        var lastDigit = CnpjAlfanumericoRule.CalculateDigitValue(sums[1]);

        var lastTwoDigits = beforeLastDigit.ToString() + lastDigit.ToString();
        return normalized.EndsWith(lastTwoDigits);
    }

    /// <summary>
    /// Places the CNPJ mask (XX.XXX.XXX/XXXX-XX) on an alphanumeric CNPJ.
    /// </summary>
    /// <param name="value">CNPJ value (alphanumeric, without mask).</param>
    /// <returns>Masked CNPJ or null if input is null/empty.</returns>
    public static string PlaceMask(string value)
    {
        return string.IsNullOrEmpty(value?.Trim())
            ? default
            : Regex.Replace(RemoveCnpjMask(value), @"(.{2})(.{3})(.{3})(.{4})(.{2})", "$1.$2.$3/$4-$5");
    }

    /// <summary>
    /// Removes CNPJ mask characters (., /, -) while preserving alphanumeric characters.
    /// </summary>
    /// <param name="value">CNPJ value with mask.</param>
    /// <returns>CNPJ without mask characters.</returns>
    public static string RemoveMask(string value)
    {
        return RemoveCnpjMask(value);
    }

    private static string RemoveCnpjMask(string value)
    {
        return value is null ? string.Empty : CnpjMaskRegex.Replace(value, string.Empty);
    }

    private static bool HasValidParams(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length != 14)
            return false;

        // Check for repeated character sequences (AAAAAAAAAAAAAA, 00000000000000, etc.)
        if (IsRepeatedSequence(value))
            return false;

        // Validate character set: first 12 alphanumeric (A-Z, 0-9), last 2 numeric (0-9)
        for (int i = 0; i < 12; i++)
        {
            char c = value[i];
            if (!char.IsLetterOrDigit(c) || (char.IsLetter(c) && !IsUpperCaseLetter(c)))
                return false;
        }

        if (!char.IsDigit(value[12]) || !char.IsDigit(value[13]))
            return false;

        return true;
    }

    private static bool IsRepeatedSequence(string value)
    {
        char first = value[0];
        for (int i = 1; i < value.Length; i++)
        {
            if (value[i] != first)
                return false;
        }
        return true;
    }

    private static bool IsUpperCaseLetter(char c)
    {
        return c >= 'A' && c <= 'Z';
    }

    private static int[] GetSum(string value)
    {
        int[] sums = { 0, 0 };

        for (var i = 0; i < 12; i++)
        {
            int charValue = CnpjAlfanumericoRule.CharToAsciiValue(value[i]);
            sums[0] += charValue * CnpjAlfanumericoRule.CalculateBeforeLastDigitWeight(i);
            sums[1] += charValue * CnpjAlfanumericoRule.CalculateLastDigitWeight(i);
        }

        // Add 13th character (first check digit) to second sum with weight 2
        int thirteenthCharValue = CnpjAlfanumericoRule.CharToAsciiValue(value[12]);
        sums[1] += thirteenthCharValue * 2;

        return sums;
    }
}