using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class RoraimaExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Roraima IE")]
    [InlineData("240066281", "24006628-1")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRr();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskRr();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Roraima IE")]
    [InlineData("240066281", "24006628-1")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
