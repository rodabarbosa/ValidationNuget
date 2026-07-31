using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Extensions;

/// <summary>
/// Extension methods for CNPJ Alfanumérico validation and formatting.
/// </summary>
public static class CnpjAlfanumericoExtension
{
    /// <summary>
    /// Validates an alphanumeric CNPJ (new RFB format).
    /// </summary>
    /// <param name="value">CNPJ value (with or without mask).</param>
    /// <returns>True if valid, false otherwise.</returns>
    public static bool IsCnpjAlfanumericoValid(this string value)
    {
        return CnpjAlfanumericoValidation.IsValid(value);
    }

    /// <summary>
    /// Places the CNPJ mask (XX.XXX.XXX/XXXX-XX) on an alphanumeric CNPJ.
    /// </summary>
    /// <param name="value">CNPJ value (alphanumeric, without mask).</param>
    /// <returns>Masked CNPJ or null if input is null/empty.</returns>
    public static string PlaceCnpjAlfanumericoMask(this string value)
    {
        return CnpjAlfanumericoValidation.PlaceMask(value);
    }

    /// <summary>
    /// Removes CNPJ mask characters (., /, -) while preserving alphanumeric characters.
    /// </summary>
    /// <param name="value">CNPJ value with mask.</param>
    /// <returns>CNPJ without mask characters.</returns>
    public static string RemoveCnpjAlfanumericoMask(this string value)
    {
        return CnpjAlfanumericoValidation.RemoveMask(value);
    }
}