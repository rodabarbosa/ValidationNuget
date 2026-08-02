using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRondoniaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Rondônia IE")]
    public void ValidateRO()
    {
        var value = InscricaoEstadual.Generate(State.RO);
        var isValid = InscricaoEstadualValidation.IsValid(State.RO, value);
        Assert.True(isValid);
    }
}
