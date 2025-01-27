namespace Sirb.Validation.Test.Extensions;

public class AmazonasExtensionTest
{
    [Theory]
    [InlineData("999999999", "99.999.999-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAm();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("999999999", "99.999.999-9")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAp();
        Assert.NotEqual(expected, maskedValue);
    }
}