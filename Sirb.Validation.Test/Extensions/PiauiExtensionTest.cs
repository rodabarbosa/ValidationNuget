namespace Sirb.Validation.Test.Extensions;

public class PiauiExtensionTest
{
    [Theory]
    [InlineData("012345679", "012345679")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskPi();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("012345679", "012345679")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskGo();
        Assert.NotEqual(expected, maskedValue);
    }
}