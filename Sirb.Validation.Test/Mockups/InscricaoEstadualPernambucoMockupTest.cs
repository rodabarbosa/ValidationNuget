using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualPernambucoMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PE);
        var isValid = InscricaoEstadualValidation.IsValid(State.PE, value);
        Assert.True(isValid);
    }
}