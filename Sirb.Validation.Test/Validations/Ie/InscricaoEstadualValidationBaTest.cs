using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationBaTest
{
    private readonly State _state = State.BA;

    [Theory(DisplayName = "Inscrição Estadual de Bahia deve ser válida")]
    [InlineData("123456-63")]
    [InlineData("612345-57")]
    [InlineData("3751607-78")]
    [InlineData("2439484-15")]
    [InlineData("5562310-44")]
    [InlineData("4984379-56")]
    [InlineData("2552624-31")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Bahia não deve ser válida")]
    [InlineData("223456-63")]
    [InlineData("312345-57")]
    [InlineData("4000003-0")]
    [InlineData("5000004-8")]
    [InlineData("6000005-6")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
