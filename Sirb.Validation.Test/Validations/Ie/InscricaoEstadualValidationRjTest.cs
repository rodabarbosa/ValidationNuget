using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRjTest
{
    private readonly State _state = State.RJ;

    [Theory(DisplayName = "Inscrição Estadual de Rio de Janeiro deve ser válida")]
    [InlineData("99.999.99-3")]
    [InlineData("10.000.01-0")]
    [InlineData("10.000.02-8")]
    [InlineData("10.000.03-6")]
    [InlineData("10.000.04-4")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Rio de Janeiro não deve ser válida")]
    [InlineData("0-9.999.99-3")]
    [InlineData("20.000.01-0")]
    [InlineData("30.000.02-8")]
    [InlineData("40.000.03-6")]
    [InlineData("50.000.04-4")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
