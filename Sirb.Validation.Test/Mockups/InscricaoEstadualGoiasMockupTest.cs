using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualGoiasMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Goiás IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.GO);
        var isValid = InscricaoEstadualValidation.IsValid(State.GO, value);
        Assert.True(isValid);
    }
}
