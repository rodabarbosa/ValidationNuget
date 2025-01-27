using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualGoiasMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.GO);
        var isValid = InscricaoEstadualValidation.IsValid(State.GO, value);
        Assert.True(isValid);
    }
}