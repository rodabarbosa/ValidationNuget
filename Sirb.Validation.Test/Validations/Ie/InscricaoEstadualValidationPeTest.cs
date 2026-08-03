using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationPeTest
{
    private readonly State _state = State.PE;

    [Theory(DisplayName = "Inscrição Estadual de Pernambuco deve ser válida")]
    [InlineData("037460110")]
    [InlineData("0321418-40")]
    [InlineData("2198285-63")]
    [InlineData("3540814-62")]
    [InlineData("9058736-70")]
    [InlineData("0623872-60")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Pernambuco não deve ser válida")]
    [InlineData("047460110")]
    [InlineData("0421418-40")]
    [InlineData("19.1.001.0000004-9")]
    [InlineData("0117789-21")]
    [InlineData("0217790-65")]
    [InlineData("0417791-46")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }

    [Fact(DisplayName = "Inscrição Estadual de Pernambuco não deve ser válida para entrada nula")]
    public void Validate_NullInput_ReturnsFalse()
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, null);
        Assert.False(isValid);
    }
}
