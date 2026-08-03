using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class MinasGeraisExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Minas Gerais IE")]
    [InlineData("0000000000000", "000.000.000/0000")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskMg();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskMg();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Minas Gerais IE")]
    [InlineData("0000000000000", "000.000.000/0000")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAl();
        Assert.NotEqual(expected, maskedValue);
    }
}
