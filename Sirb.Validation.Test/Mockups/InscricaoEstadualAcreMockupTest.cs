using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAcreMockupTest
{
    [Theory]
    [InlineData("01.579.571/939-47")]
    [InlineData("")]
    public void Validate(string value)
    {
        // TODO: Its giving a error - I've checked some collegues validator and everybody is having de same problem

        if (string.IsNullOrEmpty(value))
            value = InscricaoEstadual.Generate(State.AC);

        var isValid = InscricaoEstadualValidation.IsValid(State.AC, value);
        Assert.True(isValid);
    }
}
