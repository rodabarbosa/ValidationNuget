using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationMgTest
{
    private readonly State _state = State.MG;

    [Theory(DisplayName = "Inscrição Estadual de Minas Gerais deve ser válida")]
    [InlineData("062.000.000/0001")]
    [InlineData("062.000.000/0002")]
    [InlineData("062.000.000/0003")]
    [InlineData("062.000.000/0004")]
    [InlineData("062.000.000/0005")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Minas Gerais não deve ser válida")]
    [InlineData("162.000.000/0001")]
    [InlineData("262.000.000/0002")]
    [InlineData("362.000.000/0003")]
    [InlineData("462.000.000/0004")]
    [InlineData("562.000.000/0005")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
