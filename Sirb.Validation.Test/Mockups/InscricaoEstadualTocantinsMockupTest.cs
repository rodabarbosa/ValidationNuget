using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualTocantinsMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Tocantins IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.TO);
        var isValid = InscricaoEstadualValidation.IsValid(State.TO, value);
        Assert.True(isValid);
    }
}
