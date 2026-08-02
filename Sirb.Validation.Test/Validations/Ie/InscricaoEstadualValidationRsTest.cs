using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRsTest
{
    private readonly State _state = State.RS;

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Sul deve ser válida")]
    [InlineData("263/4318841")]
    [InlineData("115/4597242")]
    [InlineData("379/3466576")]
    [InlineData("419/8852056")]
    [InlineData("567/0004600")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Rio Grande do Sul não deve ser válida")]
    [InlineData("725/0000010")]
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
