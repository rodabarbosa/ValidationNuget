using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualDistritoFederalMockupTest
{
    [Fact]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.DF);
        var isValid = InscricaoEstadualValidation.IsValid(State.DF, value);
        Assert.True(isValid);
    }
}