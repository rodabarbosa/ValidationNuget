namespace Sirb.Validation.Test.Extensions;

public class BahiaExtensionTest
{
    [Theory]
    [InlineData("12345663", "123456-63")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskBa();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("12345663", "123456-63")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskCe();
        Assert.NotEqual(expected, maskedValue);
    }
}