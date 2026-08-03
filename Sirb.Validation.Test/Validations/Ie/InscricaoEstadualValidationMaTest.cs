using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationMaTest
{
    private readonly State _state = State.MA;

    [Theory(DisplayName = "Inscrição Estadual de Maranhão deve ser válida")]
    [InlineData("12463436-2")]
    [InlineData("12332363-0")]
    [InlineData("12688143-0")]
    [InlineData("12104156-5")]
    [InlineData("12778021-1")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Maranhão não deve ser válida")]
    [InlineData("220000038")]
    [InlineData("320000046")]
    [InlineData("420000055")]
    [InlineData("520000062")]
    [InlineData("620000070")]
    [InlineData("99999999")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
