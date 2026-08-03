using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAcreMockupTest
{
    [Theory(DisplayName = "InscricaoEstadual.Generate should produce an Acre IE with correct format (13 digits, prefix 01)")]
    [InlineData(2000)]
    public void Validate_Format(int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            var value = InscricaoEstadual.Generate(State.AC);

            // AC IE format: 13 numeric digits starting with "01"
            Assert.NotNull(value);
            Assert.Equal(13, value.Length);
            Assert.StartsWith("01", value);
            Assert.All(value, c => Assert.True(char.IsDigit(c)));
        }
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Acre IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.AC);
            var isValid = InscricaoEstadualValidation.IsValid(State.AC, value);
            Assert.True(isValid, $"Generated AC IE '{value}' should be valid (iteration {i})");
        }
    }
}
