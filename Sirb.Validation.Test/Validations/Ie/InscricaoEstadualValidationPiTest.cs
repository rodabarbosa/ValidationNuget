using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationPiTest
{
    private readonly State _state = State.PI;

    [Theory(DisplayName = "Inscrição Estadual de Piauí deve ser válida")]
    [InlineData("012345679")]
    [InlineData("012345687")]
    [InlineData("012345695")]
    [InlineData("012345709")]
    [InlineData("012345717")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Piauí não deve ser válida")]
    [InlineData("112345679")]
    [InlineData("212345687")]
    [InlineData("312345695")]
    [InlineData("412345709")]
    [InlineData("512345717")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
