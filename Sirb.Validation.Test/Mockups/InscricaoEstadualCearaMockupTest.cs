using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualCearaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.CE);
        var isValid = InscricaoEstadualValidation.IsValid(State.CE, value);
        Assert.True(isValid);
    }
}