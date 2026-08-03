using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationPaTest
{
    private readonly State _state = State.PA;

    [Theory(DisplayName = "Inscrição Estadual de Pará deve ser válida")]
    [InlineData("15-000001-4")]
    [InlineData("15-000002-2")]
    [InlineData("15-000003-0")]
    [InlineData("15-000004-9")]
    [InlineData("15-000005-7")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Pará não deve ser válida")]
    [InlineData("25-000001-4")]
    [InlineData("35-000002-2")]
    [InlineData("45-000003-0")]
    [InlineData("55-000004-9")]
    [InlineData("65-000005-7")]
    [InlineData("99999999")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
