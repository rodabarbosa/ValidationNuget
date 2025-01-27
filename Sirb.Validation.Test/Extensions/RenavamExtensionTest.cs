namespace Sirb.Validation.Test.Extensions;

public class RenavamExtensionTest
{
    [Theory]
    [InlineData("97091043703")]
    [InlineData("197073212")]
    [InlineData("00639884962")]
    public void Validate_Valid(string value)
    {
        var isValid = value.IsRenavamValid();
        Assert.True(isValid);
    }
}