using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class PisExtensionTest
{
    [Theory(DisplayName = "IsPisValid should return true for a valid PIS")]
    [InlineData("56303289843")]
    [InlineData("80589607730")]
    public void Validate_Valid(string value)
    {
        var isValid = value.IsPisValid();
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsPisValid should return false for an invalid PIS")]
    [InlineData("80589607700")]
    [InlineData("27593988377")]
    public void Validate_Invalid(string value)
    {
        var isValid = value.IsPisValid();
        Assert.False(isValid);
    }

    [Theory(DisplayName = "PlacePisMask should format a PIS correctly")]
    [InlineData("53768723133")]
    public void PlaceMask(string value)
    {
        var masked = value.PlacePisMask();
        Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", masked);
    }
}
