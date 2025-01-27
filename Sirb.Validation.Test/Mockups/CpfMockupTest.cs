namespace Sirb.Validation.Test.Mockups;

public class CpfMockupTest
{
    [Fact]
    public void GenerateAndValidate()
    {
        var value = Cpf.Generate();
        var isValid = CpfValidation.IsValid(value);
        Assert.True(isValid);
    }
}