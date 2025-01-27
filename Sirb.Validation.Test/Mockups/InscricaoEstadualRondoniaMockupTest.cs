using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRondoniaMockupTest
{
    [Fact]
    public void ValidateRO()
    {
        var value = InscricaoEstadual.Generate(State.RO);
        var isValid = InscricaoEstadualValidation.IsValid(State.RO, value);
        Assert.True(isValid);
    }
}