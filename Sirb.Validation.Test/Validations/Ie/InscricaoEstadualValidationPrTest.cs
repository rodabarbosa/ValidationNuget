using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationPrTest
{
    private readonly State _state = State.PR;

    [Theory(DisplayName = "Inscrição Estadual de Paraná deve ser válida")]
    [InlineData("123.45678-50")]
    [InlineData("050.62455-24")]
    [InlineData("051.40396-74")]
    [InlineData("074.39961-43")]
    [InlineData("342.07673-49")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Paraná não deve ser válida")]
    [InlineData("223.45678-50")]
    [InlineData("323.45679-31")]
    [InlineData("423.45680-75")]
    [InlineData("523.45681-56")]
    [InlineData("623.45682-37")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
