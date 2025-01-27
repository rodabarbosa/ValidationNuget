using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRoraimaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RR);
        var isValid = InscricaoEstadualValidation.IsValid(State.RR, value);
        Assert.True(isValid);
    }
}