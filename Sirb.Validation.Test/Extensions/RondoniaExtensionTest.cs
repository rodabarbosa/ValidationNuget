namespace Sirb.Validation.Test.Extensions;

public class RondoniaExtensionTest
{
    [Theory]
    [InlineData("01625213", "01.62521-3")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRo();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("01625213", "01.62521-3")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}