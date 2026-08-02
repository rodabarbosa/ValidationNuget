using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationSeTest
{
    private readonly State _state = State.SE;

    [Theory(DisplayName = "Inscrição Estadual de Sergipe deve ser válida")]
    [InlineData("68905292-8")]
    [InlineData("17818507-8")]
    [InlineData("38181243-0")]
    [InlineData("06683561-5")]
    [InlineData("43173104-7")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Sergipe não deve ser válida")]
    [InlineData("10000001-7")]
    [InlineData("30000002-5")]
    [InlineData("30000003-3")]
    [InlineData("40000004-1")]
    [InlineData("50000005-5")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
