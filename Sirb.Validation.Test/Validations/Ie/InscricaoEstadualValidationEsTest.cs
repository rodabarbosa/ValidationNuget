using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationEsTest
{
    private readonly State _state = State.ES;

    [Theory(DisplayName = "Inscrição Estadual de Espírito Santo deve ser válida")]
    [InlineData("50486075-5")]
    [InlineData("81945626-8")]
    [InlineData("34565088-3")]
    [InlineData("00834536-8")]
    [InlineData("44812361-4")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Espírito Santo não deve ser válida")]
    [InlineData("10000001-2")]
    [InlineData("20000006-5")]
    [InlineData("30000004-7")]
    [InlineData("40000003-9")]
    [InlineData("50000002-0")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
