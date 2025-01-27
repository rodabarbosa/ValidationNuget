using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualEspiritoSantoMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.ES);
        var isValid = InscricaoEstadualValidation.IsValid(State.ES, value);
        Assert.True(isValid);
    }
}