using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualMaranhaoMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MA);
        var isValid = InscricaoEstadualValidation.IsValid(State.MA, value);
        Assert.True(isValid);
    }
}