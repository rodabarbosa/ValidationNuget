using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualDistritoFederalMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Distrito Federal IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.DF);
        var isValid = InscricaoEstadualValidation.IsValid(State.DF, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Distrito Federal IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.DF);
            var isValid = InscricaoEstadualValidation.IsValid(State.DF, value);
            Assert.True(isValid, $"Generated IE '{value}' should be valid (iteration {i})");
        }
    }

}
