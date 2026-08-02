using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class EspiritoSantoExtensionTest
{
    [Theory(DisplayName = "InscricaoEstadualMask should return correct masked value for valid Espírito Santo IE")]
    [InlineData("0011111122233", "0011111122233")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory(DisplayName = "InscricaoEstadualMask should not return the same value for invalid Espírito Santo IE")]
    [InlineData("0011111122233", "00.111111.222-33")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}
