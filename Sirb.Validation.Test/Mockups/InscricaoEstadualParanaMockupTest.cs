using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualParanaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PR);
        var isValid = InscricaoEstadualValidation.IsValid(State.PR, value);
        Assert.True(isValid);
    }
}