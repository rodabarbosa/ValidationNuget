using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualBahiaMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.BA);
        var isValid = InscricaoEstadualValidation.IsValid(State.BA, value);
        Assert.True(isValid);
    }
}