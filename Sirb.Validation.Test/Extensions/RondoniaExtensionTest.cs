using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class RondoniaExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Rondônia IE")]
    [InlineData("01625213", "01.62521-3")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRo();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskRo();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Rondônia IE")]
    [InlineData("01625213", "01.62521-3")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
