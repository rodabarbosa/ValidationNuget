namespace Sirb.Validation.Test.Validations;

public class CnpjValidationTest
{
    [Theory]
    [InlineData("49.616.903/0001-90")]
    [InlineData("72.923.755/0001-79")]
    public void Validate_Valid(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("49.616.903/0001-00")]
    [InlineData("72.923.755/0001-70")]
    [InlineData("00.000.000/0000-00")]
    public void Validate_Invalid(string value)
    {
        var isValid = CnpjValidation.IsValid(value);
        Assert.False(isValid);
    }
}