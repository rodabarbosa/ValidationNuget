using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class MaranhaoExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Maranhão IE")]
    [InlineData("0600030790481", "06.000.307/904-81")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskMa();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Maranhão IE")]
    [InlineData("0600030790481", "06.000.307/904-81")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
