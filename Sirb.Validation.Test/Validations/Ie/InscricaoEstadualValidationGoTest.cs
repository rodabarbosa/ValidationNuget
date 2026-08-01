using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationGoTest
{
    private readonly State _state = State.GO;

    [Theory(DisplayName = "Inscrição Estadual de Goiás deve ser válida")]
    [InlineData("10.123.456-7")]
    [InlineData("10.123.457-5")]
    [InlineData("10.123.458-3")]
    [InlineData("10.123.459-1")]
    [InlineData("10.123.460-5")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Goiás não deve ser válida")]
    [InlineData("21.123.456-7")]
    [InlineData("30.123.456-7")]
    [InlineData("40.123.457-5")]
    [InlineData("50.123.458-3")]
    [InlineData("60.123.459-1")]
    [InlineData("70.123.460-5")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
