namespace Sirb.Validation.Test.Mockups;

public class CnpjMockupTest
{
    [Fact]
    public void GenerateAndValidate()
    {
        var value = Cnpj.Generate();
        var isValid = CnpjValidation.IsValid(value);
        Assert.True(isValid);
    }
}