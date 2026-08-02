using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualBahiaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Bahia IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.BA);
        var isValid = InscricaoEstadualValidation.IsValid(State.BA, value);
        Assert.True(isValid);
    }
}
