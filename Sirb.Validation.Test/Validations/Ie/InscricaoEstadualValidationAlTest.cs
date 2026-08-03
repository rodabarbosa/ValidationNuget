using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationAlTest
{
    private readonly State _state = State.AL;

    [Theory(DisplayName = "Inscrição Estadual de Alagoas deve ser válida")]
    [InlineData("240000048")]
    [InlineData("240000056")]
    [InlineData("240000064")]
    [InlineData("240000072")]
    [InlineData("240000080")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Alagoas não deve ser válida")]
    [InlineData("340000048")]
    [InlineData("440000056")]
    [InlineData("540000064")]
    [InlineData("640000072")]
    [InlineData("740000080")]
    [InlineData("24000048")]
    [InlineData("241000048")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
