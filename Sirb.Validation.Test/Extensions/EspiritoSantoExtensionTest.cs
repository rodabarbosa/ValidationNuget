namespace Sirb.Validation.Test.Extensions;

public class EspiritoSantoExtensionTest
{
    [Theory]
    [InlineData("0011111122233", "0011111122233")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("0011111122233", "00.111111.222-33")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}