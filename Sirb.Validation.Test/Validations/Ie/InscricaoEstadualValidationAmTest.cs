using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationAmTest
{
    private readonly State _state = State.AM;

    [Theory(DisplayName = "Inscrição Estadual de Amazonas deve ser válida")]
    [InlineData("04.100.001-9")]
    [InlineData("04.100.002-7")]
    [InlineData("04.100.003-5")]
    [InlineData("04.100.004-3")]
    [InlineData("04.100.005-1")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Amazonas não deve ser válida")]
    [InlineData("05.100.001-9")]
    [InlineData("06.100.002-7")]
    [InlineData("07.100.003-5")]
    [InlineData("08.100.004-3")]
    [InlineData("09.100.005-1")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
