namespace Sirb.Validation.Test.Extensions;

public class CearaExtensionTest
{
    [Theory]
    [InlineData("060000015", "06000001-5")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskCe();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("060000015", "06000001-5")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskDf();
        Assert.NotEqual(expected, maskedValue);
    }
}