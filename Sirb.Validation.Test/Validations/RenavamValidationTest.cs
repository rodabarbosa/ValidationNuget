using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class RenavamValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid Renavam")]
    [InlineData("97091043703")]
    [InlineData("197073212")]
    [InlineData("00639884962")]
    public void Validate_Valid(string value)
    {
        var isValid = RenavamValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullEmptyWhitespace_ReturnsFalse(string value)
    {
        var isValid = RenavamValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for Renavam with invalid length")]
    [InlineData("123")]
    [InlineData("12345678")]
    [InlineData("123456789012")]
    public void Validate_InvalidLength_ReturnsFalse(string value)
    {
        var isValid = RenavamValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Fact(DisplayName = "RemoveMask should return null for null input")]
    public void RemoveMask_Null_ReturnsNull()
    {
        var result = RenavamValidation.RemoveMask(null);
        Assert.Null(result);
    }

    [Theory(DisplayName = "CalculateastDigit should return 0 when summationValue % 11 is 0 or 1")]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(11)]
    [InlineData(12)]
    public void CalculateastDigit_CalculatedValueGreaterThanTen_ReturnsZero(int summationValue)
    {
        var result = RenavanRules.CalculateastDigit(summationValue);
        Assert.Equal(0, result);
    }

    [Fact(DisplayName = "CalculateastDigit should return calculatedValue when < 10")]
    public void CalculateastDigit_CalculatedValueLessThanTen_ReturnsValue()
    {
        var result = RenavanRules.CalculateastDigit(2);
        Assert.Equal(9, result);
    }
}
