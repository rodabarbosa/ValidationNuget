namespace Sirb.Validation.Documents.BR.Rules;

/// <summary>
/// Validation rules for CNPJ Alfanumérico (new RFB format).
/// Uses ASCII-48 character conversion for alphanumeric support.
/// </summary>
internal static class CnpjAlfanumericoRule
{
    /// <summary>
    /// Calculates the weight for the first check digit (before-last digit).
    /// Weights: 5,4,3,2,9,8,7,6,5,4,3,2 for positions 0-11.
    /// </summary>
    /// <param name="index">Zero-based position index (0-11).</param>
    /// <returns>Weight value for the position.</returns>
    public static int CalculateBeforeLastDigitWeight(int index)
    {
        var value = index < 4 ? 5 : 13;
        return value - index;
    }

    /// <summary>
    /// Calculates the weight for the second check digit (last digit).
    /// Weights: 6,5,4,3,2,9,8,7,6,5,4,3,2 for positions 0-12.
    /// </summary>
    /// <param name="index">Zero-based position index (0-12).</param>
    /// <returns>Weight value for the position.</returns>
    public static int CalculateLastDigitWeight(int index)
    {
        var value = index < 5 ? 6 : 14;
        return value - index;
    }

    /// <summary>
    /// Calculates the check digit value using modulo 11 algorithm.
    /// </summary>
    /// <param name="summationValue">Sum of products of character values and weights.</param>
    /// <returns>Check digit (0-9).</returns>
    public static int CalculateDigitValue(int summationValue)
    {
        var remainder = summationValue % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }

    /// <summary>
    /// Converts a character to its numeric value for modulo 11 calculation using ASCII-48.
    /// Digits '0'-'9' (ASCII 48-57) -> 0-9.
    /// Letters 'A'-'Z' (ASCII 65-90) -> 17-42.
    /// </summary>
    /// <param name="c">Character to convert.</param>
    /// <returns>Numeric value for calculation.</returns>
    public static int CharToAsciiValue(char c)
    {
        return c - 48;
    }
}