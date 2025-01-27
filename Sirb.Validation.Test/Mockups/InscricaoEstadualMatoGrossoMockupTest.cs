using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualMatoGrossoMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MT);
        var isValid = InscricaoEstadualValidation.IsValid(State.MT, value);
        Assert.True(isValid);
    }
}