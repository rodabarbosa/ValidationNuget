using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationDfTest
{
    private readonly State _state = State.DF;

    [Theory(DisplayName = "Inscrição Estadual de Distrito Federal deve ser válida")]
    [InlineData("07300001001-09")]
    [InlineData("07300001002-81")]
    [InlineData("07300001003-62")]
    [InlineData("07300001004-43")]
    [InlineData("07300001005-24")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Distrito Federal não deve ser válida")]
    [InlineData("17300001001-09")]
    [InlineData("27300001002-81")]
    [InlineData("37300001003-62")]
    [InlineData("47300001004-43")]
    [InlineData("57300001005-24")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
