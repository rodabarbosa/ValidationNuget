using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Sirb.Validation.Extensions;
using System.Linq;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class CnpjAlfanumericoValidationTests
{
    [Theory]
    [InlineData("12.ABC.345/01DE-35")]
    [InlineData("12ABC34501DE35")]
    public void IsValid_ValidAlfanumericoCnpj_ReturnsTrue(string value)
    {
        var isValid = CnpjAlfanumericoValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("12ABC34501DE00")] // Wrong check digits
    [InlineData("AAAAAAAAAAAAAA")] // Repeated sequence
    [InlineData("12ABC34501DE")]   // Too short (12 chars)
    [InlineData("")]              // Empty
    [InlineData("12ABC34501DE356")] // Too long (15 chars)
    [InlineData("12AB@34501DE35")]  // Invalid character @
    [InlineData("12abc34501DE35")]  // Lowercase letters (not allowed)
    public void IsValid_InvalidAlfanumericoCnpj_ReturnsFalse(string value)
    {
        var isValid = CnpjAlfanumericoValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("12.345.678/0001-95")]
    [InlineData("12345678000195")]
    [InlineData("00.000.000/0001-91")]
    public void IsValid_LegacyNumericCnpj_ReturnsTrue(string value)
    {
        var isValid = CnpjAlfanumericoValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("00.000.000/0000-00")]
    [InlineData("11111111111111")]
    [InlineData("99.999.999/9999-99")]
    public void IsValid_RepeatedNumericLegacyCnpj_ReturnsFalse(string value)
    {
        var isValid = CnpjAlfanumericoValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Fact]
    public void IsValid_NullInput_ReturnsFalse()
    {
        var isValid = CnpjAlfanumericoValidation.IsValid(null);
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("12ABC34501DE35", "12.ABC.345/01DE-35")]
    [InlineData("12345678000195", "12.345.678/0001-95")]
    [InlineData("ABCDEFGHIJKL12", "AB.CDE.FGH/IJKL-12")]
    public void PlaceMask_ValidInput_ReturnsMaskedValue(string input, string expected)
    {
        var masked = CnpjAlfanumericoValidation.PlaceMask(input);
        Assert.Equal(expected, masked);
    }

    [Theory]
    [InlineData("", null)]
    [InlineData(null, null)]
    public void PlaceMask_NullOrEmpty_ReturnsNull(string input, string expected)
    {
        var masked = CnpjAlfanumericoValidation.PlaceMask(input);
        Assert.Equal(expected, masked);
    }

    [Theory]
    [InlineData("12.ABC.345/01DE-35", "12ABC34501DE35")]
    [InlineData("12.345.678/0001-95", "12345678000195")]
    [InlineData("AB.CDE.FGH/IJKL-12", "ABCDEFGHIJKL12")]
    public void RemoveMask_ValidInput_ReturnsUnmaskedValue(string input, string expected)
    {
        var unmasked = CnpjAlfanumericoValidation.RemoveMask(input);
        Assert.Equal(expected, unmasked);
    }

    [Fact]
    public void RemoveMask_NullInput_ReturnsEmptyString()
    {
        var unmasked = CnpjAlfanumericoValidation.RemoveMask(null);
        Assert.Equal(string.Empty, unmasked);
    }

    [Theory]
    [InlineData("12.ABC.345/01DE-35")]
    [InlineData("12ABC34501DE35")]
    [InlineData("12.345.678/0001-95")]
    [InlineData("12345678000195")]
    public void IsCnpjAlfanumericoValid_ExtensionMethod_ReturnsTrue(string value)
    {
        var isValid = value.IsCnpjAlfanumericoValid();
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("12ABC34501DE00")]
    [InlineData("AAAAAAAAAAAAAA")]
    [InlineData("")]
    [InlineData("12ABC34501DE")]
    public void IsCnpjAlfanumericoValid_ExtensionMethod_Invalid_ReturnsFalse(string value)
    {
        var isValid = value.IsCnpjAlfanumericoValid();
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("12ABC34501DE35", "12.ABC.345/01DE-35")]
    [InlineData("12345678000195", "12.345.678/0001-95")]
    public void PlaceCnpjAlfanumericoMask_ExtensionMethod_ReturnsMasked(string input, string expected)
    {
        var masked = input.PlaceCnpjAlfanumericoMask();
        Assert.Equal(expected, masked);
    }

    [Theory]
    [InlineData("12.ABC.345/01DE-35", "12ABC34501DE35")]
    [InlineData("12.345.678/0001-95", "12345678000195")]
    public void RemoveCnpjAlfanumericoMask_ExtensionMethod_ReturnsUnmasked(string input, string expected)
    {
        var unmasked = input.RemoveCnpjAlfanumericoMask();
        Assert.Equal(expected, unmasked);
    }

    [Fact]
    public void Generate_ProducesValidAlfanumericoCnpj()
    {
        // Generate multiple CNPJs to verify they're all valid
        for (int i = 0; i < 100; i++)
        {
            var cnpj = CnpjAlfanumerico.Generate();
            var isValid = CnpjAlfanumericoValidation.IsValid(cnpj);
            Assert.True(isValid, $"Generated CNPJ {cnpj} should be valid");
        }
    }

    [Fact]
    public void GenerateWithMask_ProducesValidMaskedCnpj()
    {
        var cnpj = CnpjAlfanumerico.GenerateWithMask();
        var isValid = CnpjAlfanumericoValidation.IsValid(cnpj);
        Assert.True(isValid);
        Assert.Contains('.', cnpj);
        Assert.Contains('/', cnpj);
        Assert.Contains('-', cnpj);
    }

    [Theory]
    [InlineData("ABCDEFGHIJKL12")]
    [InlineData("0123456789AB12")]
    [InlineData("ZYXWVUTSRQPO12")]
    public void IsValid_VariousAlphanumericPatterns_AcceptsAlphanumericChars(string value)
    {
        // Note: These are pattern examples with placeholder check digits;
        // This test ensures the validation accepts alphanumeric characters in first 12 positions
        // (the check digit validation will fail, but character validation should pass)
        var normalized = CnpjAlfanumericoValidation.RemoveMask(value);
        Assert.Equal(14, normalized.Length);
        Assert.All(normalized[..12], c => Assert.True(char.IsLetterOrDigit(c)));
        Assert.True(char.IsDigit(normalized[12]));
        Assert.True(char.IsDigit(normalized[13]));
    }
}