using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class CpfValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid CPF")]
    [InlineData("715.470.830-18")]
    [InlineData("115.327.120-65")]
    public void Validate_Valid(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for invalid CPF")]
    [InlineData("115.327.120-60")]
    [InlineData("715.470.830-33")]
    [InlineData("000.000.000-00")]
    public void Validate_Invalid(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.False(isValid);
    }
}
