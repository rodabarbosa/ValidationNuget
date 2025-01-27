using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAmapaMockupTest
{
    [Theory]
    [InlineData(10)]
    public void Validate(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var value = InscricaoEstadual.Generate(State.AP);
            var isValid = InscricaoEstadualValidation.IsValid(State.AP, value);
            Assert.True(isValid);

        }
    }
}
