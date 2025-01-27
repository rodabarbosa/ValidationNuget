namespace Sirb.Validation.Test.Extensions;

public class ParaibaExtensionTest
{
    [Theory]
    [InlineData("123456789", "12345678-9")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskPb();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("123456789", "12345678-9")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}