using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRioGrandeDoSulMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Rio Grande do Sul IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RS);
        var isValid = InscricaoEstadualValidation.IsValid(State.RS, value);
        Assert.True(isValid);
    }
}
