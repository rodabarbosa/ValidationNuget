using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class MatoGrossoExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Mato Grosso IE")]
    [InlineData("00130000019", "0013000001-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskMt();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Mato Grosso IE")]
    [InlineData("00130000019", "0013000001-9")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
