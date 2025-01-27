using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualSantaCatarinaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.SC);
        var isValid = InscricaoEstadualValidation.IsValid(State.SC, value);
        Assert.True(isValid);
    }
}