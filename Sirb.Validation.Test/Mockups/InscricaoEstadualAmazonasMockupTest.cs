using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAmazonasMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.AM);
        var isValid = InscricaoEstadualValidation.IsValid(State.AM, value);
        Assert.True(isValid);
    }
}