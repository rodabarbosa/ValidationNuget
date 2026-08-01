using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRrTest
{
    private readonly State _state = State.RR;

    [Theory(DisplayName = "Inscrição Estadual de Roraima deve ser válida")]
    [InlineData("24006651-0")]
    [InlineData("24006652-8")]
    [InlineData("24006653-6")]
    [InlineData("24006654-4")]
    [InlineData("24006655-2")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Roraima não deve ser válida")]
    [InlineData("34006651-0")]
    [InlineData("44006652-8")]
    [InlineData("54006653-6")]
    [InlineData("64006654-4")]
    [InlineData("74006655-2")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
