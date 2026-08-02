using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualMaranhaoMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Maranhão IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MA);
        var isValid = InscricaoEstadualValidation.IsValid(State.MA, value);
        Assert.True(isValid);
    }
}
