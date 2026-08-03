using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationAmTest
{
    private readonly State _state = State.AM;

    [Theory(DisplayName = "Inscrição Estadual de Amazonas deve ser válida")]
    [InlineData("48.266.330-8")]
    [InlineData("47.723.617-0")]
    [InlineData("98.115.901-0")]
    [InlineData("62.425.797-5")]
    [InlineData("77.050.041-2")]
    [InlineData("000000000")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Amazonas não deve ser válida")]
    [InlineData("05.100.001-9")]
    [InlineData("06.100.002-8")]
    [InlineData("07.100.003-5")]
    [InlineData("08.100.004-3")]
    [InlineData("09.100.005-1")]
    [InlineData("4826633")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
