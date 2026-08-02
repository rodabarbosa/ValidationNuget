using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRoraimaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Roraima IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RR);
        var isValid = InscricaoEstadualValidation.IsValid(State.RR, value);
        Assert.True(isValid);
    }
}
