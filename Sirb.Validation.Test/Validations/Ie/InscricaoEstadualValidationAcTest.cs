using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationAcTest
{
    private readonly State _state = State.AC;

    [Theory(DisplayName = "Inscrição Estadual de Acre deve ser válida")]
    [InlineData("01.004.823/001-12")]
    [InlineData("01.004.823/002-01")]
    [InlineData("01.004.823/003-84")]
    [InlineData("01.004.823/004-65")]
    [InlineData("01.004.823/005-46")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Acre não deve ser válida")]
    [InlineData("01.004.823/001-10")]
    [InlineData("02.004.823/002-04")]
    [InlineData("03.004.823/003-85")]
    [InlineData("04.004.823/004-66")]
    [InlineData("05.004.823/005-47")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
