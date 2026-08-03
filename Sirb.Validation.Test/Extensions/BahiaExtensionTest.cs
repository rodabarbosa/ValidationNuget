using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class BahiaExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Bahia IE")]
    [InlineData("12345663", "123456-63")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskBa();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskBa();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Bahia IE")]
    [InlineData("12345663", "123456-63")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskCe();
        Assert.NotEqual(expected, maskedValue);
    }
}
