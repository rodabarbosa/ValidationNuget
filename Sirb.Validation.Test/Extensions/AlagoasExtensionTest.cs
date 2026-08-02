using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class AlagoasExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Alagoas IE")]
    [InlineData("123456789", "12345678-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAl();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Alagoas IE")]
    [InlineData("123456789", "12345678-9")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAp();
        Assert.NotEqual(expected, maskedValue);
    }
}
