using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationMtTest
{
    private readonly State _state = State.MT;

    [Theory(DisplayName = "Inscrição Estadual de Mato Grosso deve ser válida")]
    [InlineData("0013000001-9")]
    [InlineData("0013000002-7")]
    [InlineData("0013000003-5")]
    [InlineData("0013000004-3")]
    [InlineData("0013000005-1")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Mato Grosso não deve ser válida")]
    [InlineData("1013000001-9")]
    [InlineData("2013000002-7")]
    [InlineData("3013000003-5")]
    [InlineData("4013000004-3")]
    [InlineData("5013000005-1")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
