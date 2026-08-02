using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class RioDeJaneiroExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Rio de Janeiro IE")]
    [InlineData("00000000", "00.000.00-0")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskRj();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Rio de Janeiro IE")]
    [InlineData("00000000", "00.000.00-0")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
