using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAlagoasMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.AL);
        var isValid = InscricaoEstadualValidation.IsValid(State.AL, value);
        Assert.True(isValid);
    }
}