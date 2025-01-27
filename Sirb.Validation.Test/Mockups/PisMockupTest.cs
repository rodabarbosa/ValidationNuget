namespace Sirb.Validation.Test.Mockups;

public class PisMockupTest
{
    [Fact]
    public void GenerateAndValidate()
    {
        var value = Pis.Generate();
        var isValid = PisValidation.IsValid(value);
        Assert.True(isValid);
    }
}