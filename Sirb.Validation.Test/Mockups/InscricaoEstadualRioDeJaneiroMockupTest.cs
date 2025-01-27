using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRioDeJaneiroMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RJ);
        var isValid = InscricaoEstadualValidation.IsValid(State.RJ, value);
        Assert.True(isValid);
    }
}