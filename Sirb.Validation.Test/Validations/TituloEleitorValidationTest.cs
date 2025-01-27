namespace Sirb.Validation.Test.Validations;

public class TituloEleitorValidationTest
{
    [Theory]
    [InlineData("470080440124")]
    [InlineData("876807870728")]
    public void Validate_Valid(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("876807870700")]
    [InlineData("316816351122")]
    public void Validate_Invalid(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("123456789012345678")]
    public void Value_Out_Of_Range_Should_Be_Invalid(string value)
    {
        var isValid = TituloEleitorValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Fact]
    public void Value_As_Text_Should_Be_Invalid()
    {
        var isValid = TituloEleitorValidation.IsValid("abc");
        Assert.False(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("      ")]
    public void Place_Mask_To_Value_Should_Return_Null(string value)
    {
        var maskedValue = TituloEleitorValidation.PlaceMask(value);
        Assert.Null(maskedValue);
    }
}
