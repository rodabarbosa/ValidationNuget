namespace Sirb.Validation.Test.Extensions;

public class MatoGrossoDoSulExtensionTest
{
    [Theory]
    [InlineData("111111111", "11.111.111-1")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskMs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("111111111", "11.111.111-1")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}