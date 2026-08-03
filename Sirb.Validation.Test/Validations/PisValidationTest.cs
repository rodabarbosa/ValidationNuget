using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class PisValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid PIS")]
    [InlineData("56303289843")]
    [InlineData("80589607730")]
    public void Validate_Valid(string value)
    {
        var isValid = PisValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for invalid PIS")]
    [InlineData("80589607700")]
    [InlineData("27593988377")]
    public void Validate_Invalid(string value)
    {
        var isValid = PisValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullEmptyWhitespace_ReturnsFalse(string value)
    {
        var isValid = PisValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for PIS with wrong length")]
    [InlineData("123")]
    [InlineData("12")]
    [InlineData("1234567890")]
    public void Validate_WrongLength_ReturnsFalse(string value)
    {
        var isValid = PisValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "PlaceMask should return null for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PlaceMask_NullEmptyWhitespace_ReturnsNull(string value)
    {
        var result = PisValidation.PlaceMask(value);
        Assert.Null(result);
    }

    [Fact(DisplayName = "RemoveMask should return null for null input")]
    public void RemoveMask_Null_ReturnsNull()
    {
        var result = PisValidation.RemoveMask(null);
        Assert.Null(result);
    }
}
