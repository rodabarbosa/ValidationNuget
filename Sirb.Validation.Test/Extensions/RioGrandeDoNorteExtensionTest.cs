namespace Sirb.Validation.Test.Extensions;

public class RioGrandeDoNorteExtensionTest
{
    [Theory]
    [InlineData("200400401", "20.040.040-1")]
    [InlineData("2000400400", "20.0.040.040-0")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRn();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskRn();
        Assert.Null(maskedValue);
    }

    [Theory]
    [InlineData("200400401", "20.040.040-1")]
    [InlineData("2000400400", "20.0.040.040-0")]
    [InlineData("", "20.0.040.040-0")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}