using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationRoTest
{
    private readonly State _state = State.RO;

    [Theory(DisplayName = "Inscrição Estadual de Rondônia deve ser válida")]
    [InlineData("6302222442488-7")]
    [InlineData("0788317165781-2")]
    [InlineData("0114896461049-0")]
    [InlineData("8464187545376-1")]
    [InlineData("1694511532698-1")]
    public void Validate_Valid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Inscrição Estadual de Rondônia não deve ser válida")]
    [InlineData("1000000177700-1")]
    [InlineData("2000000177701-0")]
    [InlineData("3000000177702-8")]
    [InlineData("4000000177703-6")]
    [InlineData("5000000177704-5")]
    public void Validate_Invalid(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.False(isValid);
    }
}
