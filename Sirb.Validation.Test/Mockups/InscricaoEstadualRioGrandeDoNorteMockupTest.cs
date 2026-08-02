using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRioGrandeDoNorteMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Rio Grande do Norte IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RN);
        var isValid = InscricaoEstadualValidation.IsValid(State.RN, value);
        Assert.True(isValid);
    }
}
