using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualTocantinsMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.TO);
        var isValid = InscricaoEstadualValidation.IsValid(State.TO, value);
        Assert.True(isValid);
    }
}