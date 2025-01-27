namespace Sirb.Validation.Test.Extensions;

public class CpfExtensionTest
{
    [Theory]
    [InlineData("71547083018")]
    public void Validate(string value)
    {
        var isValid = value.IsCpfValid();
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("71547083018")]
    public void PlaceMask(string value)
    {
        var valueMasked = value.PlaceCpfMask();
        Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", valueMasked);
    }

    [Theory]
    [InlineData("715.470.830-18")]
    public void RemoveMask(string value)
    {
        var onlyNumbers = value.RemoveMask();
        Assert.Matches(@"[\d]", onlyNumbers);
        Assert.NotEmpty(onlyNumbers);
        Assert.NotNull(onlyNumbers);
    }
}