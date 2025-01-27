using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualParaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PA);
        var isValid = InscricaoEstadualValidation.IsValid(State.PA, value);
        Assert.True(isValid);
    }
}