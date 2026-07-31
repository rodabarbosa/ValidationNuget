using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups;

/// <summary>
/// Generator of valid alphanumeric CNPJ numbers (new RFB format).
/// For testing purposes only.
/// </summary>
public static class CnpjAlfanumerico
{
    private static readonly Random _random = new();
    private const string AlphanumericChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Generates a valid alphanumeric CNPJ.
    /// </summary>
    /// <returns>Alphanumeric CNPJ without mask.</returns>
    public static string Generate()
    {
        var generatedValues = GenerateValues();
        return generatedValues.ConvertToString();
    }

    /// <summary>
    /// Generates a valid alphanumeric CNPJ with mask.
    /// </summary>
    /// <returns>Alphanumeric CNPJ with mask (XX.XXX.XXX/XXXX-XX).</returns>
    public static string GenerateWithMask()
    {
        return Generate().PlaceCnpjAlfanumericoMask();
    }

    private static int[] GenerateValues()
    {
        var generatedValues = new List<int>();

        var totalBeforeLastDigit = 0;
        var totalLastDigit = 0;

        // Generate 12 alphanumeric characters (values 0-42, where 0-9 = digits, 10-42 = A-Z)
        for (var i = 0; i < 12; i++)
        {
            // Generate random alphanumeric value (0-42)
            // 0-9 = digits, 10-42 = letters (A=10+17=27? Wait, ASCII-48: 'A'=65-48=17)
            // Actually we need to generate characters directly and convert
            char randomChar = AlphanumericChars[_random.Next(AlphanumericChars.Length)];
            int charValue = CnpjAlfanumericoRule.CharToAsciiValue(randomChar);

            generatedValues.Add(charValue);

            totalBeforeLastDigit += charValue * CnpjAlfanumericoRule.CalculateBeforeLastDigitWeight(i);
            totalLastDigit += charValue * CnpjAlfanumericoRule.CalculateLastDigitWeight(i);
        }

        // Calculate first check digit
        var beforeLastDigit = CnpjAlfanumericoRule.CalculateDigitValue(totalBeforeLastDigit);
        generatedValues.Add(beforeLastDigit);

        // Add first check digit to second sum with weight 2
        totalLastDigit += beforeLastDigit * 2;

        // Calculate second check digit
        var lastDigit = CnpjAlfanumericoRule.CalculateDigitValue(totalLastDigit);
        generatedValues.Add(lastDigit);

        return generatedValues.ToArray();
    }
}

internal static class IntArrayExtensions
{
    /// <summary>
    /// Converts an array of integer values (0-42) to alphanumeric string.
    /// Values 0-9 become '0'-'9', values 17-42 become 'A'-'Z' (ASCII-48 inverse).
    /// </summary>
    public static string ConvertToString(this int[] values)
    {
        var chars = new char[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            int v = values[i];
            if (v >= 0 && v <= 9)
                chars[i] = (char)('0' + v);
            else if (v >= 17 && v <= 42)
                chars[i] = (char)(v + 48); // Inverse of ASCII-48
            else
                chars[i] = '0'; // Fallback
        }
        return new string(chars);
    }
}