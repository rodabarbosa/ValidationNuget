using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class SaoPauloExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid São Paulo IE")]
    [InlineData("P011004243000", "P-01100424.3/000")]
    [InlineData("110042490114", "110.042.490.114")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskSp();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskSp();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid São Paulo IE")]
    [InlineData("P011004243", "P-01100424.3")]
    [InlineData("110042490114", "110.042.490.114")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskTo();
        Assert.NotEqual(expected, maskedValue);
    }
}
