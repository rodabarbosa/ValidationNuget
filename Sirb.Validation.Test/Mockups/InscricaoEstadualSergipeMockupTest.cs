using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualSergipeMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.SE);
        var isValid = InscricaoEstadualValidation.IsValid(State.SE, value);
        Assert.True(isValid);
    }
}