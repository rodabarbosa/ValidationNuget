using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRioGrandeDoSulMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RS);
        var isValid = InscricaoEstadualValidation.IsValid(State.RS, value);
        Assert.True(isValid);
    }
}