namespace Sirb.Validation.Test.Extensions;

public class RioGrandeDoSulExtensionTest
{
    [Theory]
    [InlineData("2243658792", "224/3658792")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("2243658792", "224/3658792")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}