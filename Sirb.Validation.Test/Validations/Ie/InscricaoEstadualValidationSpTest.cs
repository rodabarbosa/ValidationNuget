using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationSpTest
{
    private readonly State _state = State.SP;

    [Theory(DisplayName = "Inscrição Estadual de São Paulo deve ser válida")]
    [InlineData("110.042.490.114")]
    [InlineData("810353650643")]
    [InlineData("716.898.480.250")]
    [InlineData("043978883554")]
    [InlineData("043978883554")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de São Paulo não deve ser válida")]
    [InlineData("210.042.490.116")]
    [InlineData("310.042.490.114")]
    [InlineData("410.042.490.115")]
    [InlineData("P-91100424.9/001")]
    [InlineData("510.042.491.112")]
    [InlineData("610.042.492.110")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
