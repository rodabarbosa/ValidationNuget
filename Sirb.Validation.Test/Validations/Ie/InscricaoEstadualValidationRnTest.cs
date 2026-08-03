using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRnTest
{
    private readonly State _state = State.RN;

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Norte deve ser válida")]
    [InlineData("20.851.536-4")]
    [InlineData("20.189.644-3")]
    [InlineData("20.456.046-2")]
    [InlineData("20.631.565-1")]
    [InlineData("20.636.248-0")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Norte não deve ser válida")]
    [InlineData("30.088.251-6")]
    [InlineData("40.088.252-4")]
    [InlineData("50.088.253-2")]
    [InlineData("60.088.254-0")]
    [InlineData("70.088.255-9")]
    [InlineData("20.851.53")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
