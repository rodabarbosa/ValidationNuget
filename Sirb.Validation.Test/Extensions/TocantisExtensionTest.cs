namespace Sirb.Validation.Test.Extensions;

public class TocantisExtensionTest
{
    [Theory]
    [InlineData("123456789", "12.345.678-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskTo();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("12345663", "123456-63")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}