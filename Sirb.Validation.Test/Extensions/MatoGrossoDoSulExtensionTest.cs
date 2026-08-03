using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class MatoGrossoDoSulExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Mato Grosso do Sul IE")]
    [InlineData("111111111", "11.111.111-1")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskMs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should return null for empty input")]
    [InlineData("")]
    [InlineData(null)]
    public void InscricaoEstadualMask_Empty(string value)
    {
        var maskedValue = value.InscricaoEstadualMaskMs();
        Assert.Null(maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Mato Grosso do Sul IE")]
    [InlineData("111111111", "11.111.111-1")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
