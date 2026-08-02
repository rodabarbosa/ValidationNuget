using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualSantaCatarinaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Santa Catarina IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.SC);
        var isValid = InscricaoEstadualValidation.IsValid(State.SC, value);
        Assert.True(isValid);
    }
}
