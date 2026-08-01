using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationCeTest
{
    private readonly State _state = State.CE;

    [Theory(DisplayName = "Inscrição Estadual de Ceará deve ser válida")]
    [InlineData("06000001-5")]
    [InlineData("06000002-3")]
    [InlineData("06000003-1")]
    [InlineData("06000004-0")]
    [InlineData("06000005-8")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Ceará não deve ser válida")]
    [InlineData("16000001-5")]
    [InlineData("26000002-3")]
    [InlineData("36000003-1")]
    [InlineData("46000004-0")]
    [InlineData("56000005-8")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
