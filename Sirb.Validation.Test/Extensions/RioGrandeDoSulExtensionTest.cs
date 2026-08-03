using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class RioGrandeDoSulExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Rio Grande do Sul IE")]
    [InlineData("2243658792", "224/3658792")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskRs();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Rio Grande do Sul IE")]
    [InlineData("2243658792", "224/3658792")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
