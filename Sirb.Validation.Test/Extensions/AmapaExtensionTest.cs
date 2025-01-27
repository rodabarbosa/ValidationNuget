namespace Sirb.Validation.Test.Extensions;

public class AmapaExtensionTest
{
    [Theory]
    [InlineData("1111111111", "11.111111-11")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAp();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("1111111111", "11.111111-11")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskBa();
        Assert.NotEqual(expected, maskedValue);
    }
}