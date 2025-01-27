using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualMatoGrossoDoSulMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MS);
        var isValid = InscricaoEstadualValidation.IsValid(State.MS, value);
        Assert.True(isValid);
    }
}