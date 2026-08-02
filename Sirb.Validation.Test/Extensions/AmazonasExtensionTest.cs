using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class AmazonasExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Amazonas IE")]
    [InlineData("999999999", "99.999.999-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAm();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Amazonas IE")]
    [InlineData("999999999", "99.999.999-9")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskAp();
        Assert.NotEqual(expected, maskedValue);
    }
}
