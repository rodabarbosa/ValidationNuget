using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationEsTest
{
    private readonly State _state = State.ES;

    [Theory(DisplayName = "Inscrição Estadual de Espírito Santo deve ser válida")]
    [InlineData("00000001-2")]
    [InlineData("00000005-5")]
    [InlineData("00000004-7")]
    [InlineData("00000003-9")]
    [InlineData("00000002-0")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Espírito Santo não deve ser válida")]
    [InlineData("10000001-2")]
    [InlineData("20000005-5")]
    [InlineData("30000004-7")]
    [InlineData("40000003-9")]
    [InlineData("50000002-0")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
