using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualPiauiMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PI);
        var isValid = InscricaoEstadualValidation.IsValid(State.PI, value);
        Assert.True(isValid);
    }
}