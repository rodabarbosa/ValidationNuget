using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationSeTest
{
    private readonly State _state = State.SE;

    [Theory(DisplayName = "Inscrição Estadual de Sergipe deve ser válida")]
    [InlineData("00000001-7")]
    [InlineData("00000002-5")]
    [InlineData("00000003-3")]
    [InlineData("00000004-1")]
    [InlineData("00000005-0")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Sergipe não deve ser válida")]
    [InlineData("10000001-7")]
    [InlineData("20000002-5")]
    [InlineData("30000003-3")]
    [InlineData("40000004-1")]
    [InlineData("50000005-0")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
