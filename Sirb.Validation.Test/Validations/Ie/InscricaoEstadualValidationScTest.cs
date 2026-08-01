using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationScTest
{
    private readonly State _state = State.SC;

    [Theory(DisplayName = "Inscrição Estadual de Santa Catarina deve ser válida")]
    [InlineData("251.000.002")]
    [InlineData("251.000.003")]
    [InlineData("251.000.004")]
    [InlineData("251.000.005")]
    [InlineData("251.000.006")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Santa Catarina não deve ser válida")]
    [InlineData("351.000.002")]
    [InlineData("451.000.003")]
    [InlineData("551.000.004")]
    [InlineData("651.000.005")]
    [InlineData("751.000.006")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
