using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class InscricaoEstadualValidationTest
{
    [Fact(DisplayName = "RemoveMask should return null for null input")]
    public void RemoveMask_Null_ReturnsNull()
    {
        var result = InscricaoEstadualValidation.RemoveMask(null);
        Assert.Null(result);
    }

    [Fact(DisplayName = "RemoveMask should return empty string for empty input")]
    public void RemoveMask_Empty_ReturnsEmptyString()
    {
        var result = InscricaoEstadualValidation.RemoveMask("");
        Assert.Equal(string.Empty, result);
    }

    [Theory(DisplayName = "PlaceMask should return null for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PlaceMask_NullEmptyWhitespace_ReturnsNull(string value)
    {
        var result = InscricaoEstadualValidation.PlaceMask(State.SP, value);
        Assert.Null(result);
    }

    [Fact(DisplayName = "PlaceMask should apply mask to valid input")]
    public void PlaceMask_ValidInput_ReturnsMaskedValue()
    {
        var result = InscricaoEstadualValidation.PlaceMask(State.SP, "123456789123");
        Assert.NotNull(result);
        Assert.NotEqual("123456789123", result);
    }

    [Theory(DisplayName = "IsValid should return false for null or empty input")]
    [InlineData(null)]
    [InlineData("")]
    public void IsValid_NullOrEmpty_ReturnsFalse(string value)
    {
        var result = InscricaoEstadualValidation.IsValid(State.SP, value);
        Assert.False(result);
    }
}
