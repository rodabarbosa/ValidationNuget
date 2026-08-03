using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualSaoPauloMockupTest
{
    [Theory(DisplayName = "InscricaoEstadual.Generate should produce a valid São Paulo IE")]
    [InlineData(2000)]
    public void Validate(int retry)
    {
        for (var i = 0; i < retry; i++)
        {
            var value = InscricaoEstadual.Generate(State.SP);
            var isValid = InscricaoEstadualValidation.IsValid(State.SP, value);
            Assert.True(isValid);
        }
    }

    [Theory(DisplayName = "InscricaoEstadual.Generate should produce a valid São Paulo IE with P prefix")]
    [InlineData("P-01100424.3/002")]
    public void ValidateWithP(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(State.SP, value);
        Assert.True(isValid);
    }
}
