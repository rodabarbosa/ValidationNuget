using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationToTest
{
    private readonly State _state = State.TO;

    [Theory(DisplayName = "Inscrição Estadual de Tocantins deve ser válida")]
    [InlineData("29010227836")]
    [InlineData("29010227844")]
    [InlineData("29010227852")]
    [InlineData("29010227860")]
    [InlineData("29010227879")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Tocantins não deve ser válida")]
    [InlineData("39010227836")]
    [InlineData("49010227844")]
    [InlineData("59010227852")]
    [InlineData("69010227860")]
    [InlineData("79010227879")]
    [InlineData("2901022783")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
