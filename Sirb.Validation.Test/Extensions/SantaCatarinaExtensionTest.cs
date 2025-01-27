namespace Sirb.Validation.Test.Extensions;

public class SantaCatarinaExtensionTest
{
    [Theory]
    [InlineData("251040852", "251.040.852")]
    public void InscricaoEstadualMask_Valid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskSc();
        Assert.Equal(expected, maskedValue);
    }

    [Theory]
    [InlineData("251040852", "251.040.852")]
    public void InscricaoEstadualMask_Invalid(string value, string expected)
    {
        var maskedValue = value.InscricaoEstadualMaskEs();
        Assert.NotEqual(expected, maskedValue);
    }
}