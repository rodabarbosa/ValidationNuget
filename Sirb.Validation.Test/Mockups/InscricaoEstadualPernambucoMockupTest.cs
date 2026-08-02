using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualPernambucoMockupTest
{
    private readonly State _state = State.PE;
    [Fact(DisplayName = "Generate should work as expected for Validate")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(_state);
        var isValid = InscricaoEstadualValidation.IsValid(_state, value);
        Assert.True(isValid);
    }
}
