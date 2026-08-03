using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationApTest
{
    private readonly State _state = State.AP;

    [Theory(DisplayName = "Inscrição Estadual de Amapá deve ser válida")]
    [InlineData("030123459")]
    [InlineData("030123467")]
    [InlineData("030123475")]
    [InlineData("030123483")]
    [InlineData("030123491")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Amapá não deve ser válida")]
    [InlineData("040123459")]
    [InlineData("050123467")]
    [InlineData("060123475")]
    [InlineData("070123483")]
    [InlineData("080123491")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "Amapá IE range-specific check digit branches")]
    [InlineData("030000002", false)]
    [InlineData("030001000", true)]
    [InlineData("030170011", true)]
    [InlineData("030190231", true)]
    public void Validate_AmapaRangeBranches(string value, bool expected)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.Equal(expected, isValid);
    }
}
