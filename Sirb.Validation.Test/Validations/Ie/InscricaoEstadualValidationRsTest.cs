using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRsTest
{
    private readonly State _state = State.RS;

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Sul deve ser válida")]
    [InlineData("224/0000010")]
    [InlineData("224/0000029")]
    [InlineData("224/0000037")]
    [InlineData("224/0000045")]
    [InlineData("224/0000053")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Sul não deve ser válida")]
    [InlineData("724/0000010")]
    [InlineData("624/0000029")]
    [InlineData("524/0000037")]
    [InlineData("424/0000045")]
    [InlineData("324/0000053")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
