using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualParaibaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Paraíba IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.PB);
        var isValid = InscricaoEstadualValidation.IsValid(State.PB, value);
        Assert.True(isValid);
    }
}
