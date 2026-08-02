using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualMatoGrossoMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Mato Grosso IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MT);
        var isValid = InscricaoEstadualValidation.IsValid(State.MT, value);
        Assert.True(isValid);
    }
}
