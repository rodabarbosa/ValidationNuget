using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationMaTest
{
    private readonly State _state = State.MA;

    [Theory(DisplayName = "Inscrição Estadual de Maranhão deve ser válida")]
    [InlineData("120000038")]
    [InlineData("120000046")]
    [InlineData("120000054")]
    [InlineData("120000062")]
    [InlineData("120000070")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Maranhão não deve ser válida")]
    [InlineData("220000038")]
    [InlineData("320000046")]
    [InlineData("420000054")]
    [InlineData("520000062")]
    [InlineData("620000070")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
