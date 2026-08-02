using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class TituloEleitorExtensionTest
{
    [Theory(DisplayName = "IsTituloEleitorValid should return true for a valid Título de Eleitor")]
    [InlineData("470080440124")]
    [InlineData("876807870728")]
    public void Validate_Valid(string value)
    {
        var isValid = value.IsTituloEleitorValid();
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsTituloEleitorValid should return false for an invalid Título de Eleitor")]
    [InlineData("876807870700")]
    [InlineData("316816351122")]
    public void Validate_Invalid(string value)
    {
        var isValid = value.IsTituloEleitorValid();
        Assert.False(isValid);
    }

    [Theory(DisplayName = "PlaceTituloEleitorMask should format a Título de Eleitor correctly")]
    [InlineData("475452000132")]
    public void PlaceMask(string value)
    {
        var maskedValue = value.PlaceTituloEleitorMask();
        Assert.Matches(@"(\d{4}).(\d{4}).(\d{4})", maskedValue);
    }
}
