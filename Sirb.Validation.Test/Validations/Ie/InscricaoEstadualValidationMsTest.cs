using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationMsTest
{
    private readonly State _state = State.MS;

    [Theory(DisplayName = "Inscrição Estadual de Mato Grosso do Sul deve ser válida")]
    [InlineData("28950183-0")]
    [InlineData("28989677-0")]
    [InlineData("28897986-9")]
    [InlineData("28310299-3")]
    [InlineData("28771368-7")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Mato Grosso do Sul não deve ser válida")]
    [InlineData("38000001-8")]
    [InlineData("48000002-6")]
    [InlineData("58000003-4")]
    [InlineData("68000004-2")]
    [InlineData("78000005-0")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
