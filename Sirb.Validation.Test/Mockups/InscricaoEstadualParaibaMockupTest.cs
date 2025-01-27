using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualParaibaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PB);
        var isValid = InscricaoEstadualValidation.IsValid(State.PB, value);
        Assert.True(isValid);
    }
}