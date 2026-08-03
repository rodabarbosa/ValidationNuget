using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class TituloEleitorValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid Título de Eleitor")]
    [InlineData("470080440124")]
    [InlineData("876807870728")]
    public void Validate_Valid(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for invalid Título de Eleitor")]
    [InlineData("876807870700")]
    [InlineData("316816351122")]
    public void Validate_Invalid(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullEmptyWhitespace_ReturnsFalse(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for Título with wrong length")]
    [InlineData("12345678901")]
    [InlineData("1234567890123")]
    public void Validate_WrongLength_ReturnsFalse(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "PlaceMask should return null for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PlaceMask_NullEmptyWhitespace_ReturnsNull(string value)
    {
        var result = TituloEleitorValidation.PlaceMask(value);
        Assert.Null(result);
    }

    [Theory(DisplayName = "PlaceMask should apply mask to valid input")]
    [InlineData("470080440124", "4700.8044.0124")]
    public void PlaceMask_ValidInput_ReturnsMasked(string input, string expected)
    {
        var result = TituloEleitorValidation.PlaceMask(input);
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "IsValid should return false for state digit 0")]
    [InlineData("000000000000")]
    public void Validate_StateDigitZero_ReturnsFalse(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for state digit >= 29")]
    [InlineData("000000003099")]
    public void Validate_StateDigitGreaterThanTwentyEight_ReturnsFalse(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Fact(DisplayName = "IsValid should cover digit > 9 branch (total % 11 == 10) via generated titles")]
    public void Validate_CoversDigitGreaterThanNineBranch()
    {
        // Generate titles until we cover the digit > 9 branch
        // When total % 11 == 10, digit = 0 (the > 9 branch)
        // The loop ensures the > 9 branch in GetFirstDigit/GetSecondDigit is exercised
        for (var i = 0; i < 2000; i++)
        {
            var title = TituloEleitor.Generate();
            var isValid = TituloEleitorValidation.IsValid(title);
            Assert.True(isValid);
        }
    }
}
