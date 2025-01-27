namespace Sirb.Validation.Test.Mockups;

public class RenavamMockupTest
{
    [Fact]
    public void GenerateAndValidate()
    {
        var value = Renavam.Generate();
        var isValid = RenavamValidation.IsValid(value);
        Assert.True(isValid);
    }
}