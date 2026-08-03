using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRoraimaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Roraima IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RR);
        var isValid = InscricaoEstadualValidation.IsValid(State.RR, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Roraima IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.RR);
            var isValid = InscricaoEstadualValidation.IsValid(State.RR, value);
            Assert.True(isValid, $"Generated IE '{value}' should be valid (iteration {i})");
        }
    }

}
