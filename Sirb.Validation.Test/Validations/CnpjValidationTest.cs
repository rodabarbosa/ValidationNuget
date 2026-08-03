using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class CnpjValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid CNPJ")]
    [InlineData("49.616.903/0001-90")]
    [InlineData("72.923.755/0001-79")]
    public void Validate_Valid(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for invalid CNPJ")]
    [InlineData("49.616.903/0001-00")]
    [InlineData("72.923.755/0001-70")]
    [InlineData("00.000.000/0000-00")]
    public void Validate_Invalid(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullEmptyWhitespace_ReturnsFalse(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for CNPJ with wrong length")]
    [InlineData("123")]
    [InlineData("123456789012")]
    public void Validate_WrongLength_ReturnsFalse(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "PlaceMask should return null for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PlaceMask_NullEmptyWhitespace_ReturnsNull(string value)
    {
        var result = CnpjValidation.PlaceMask(value);
        Assert.Null(result);
    }

    [Theory(DisplayName = "PlaceMask should apply mask to valid input")]
    [InlineData("49616903000190", "49.616.903/0001-90")]
    [InlineData("12.345.678/0001-95", "12.345.678/0001-95")]
    public void PlaceMask_ValidInput_ReturnsMasked(string input, string expected)
    {
        var result = CnpjValidation.PlaceMask(input);
        Assert.Equal(expected, result);
    }
}
