using Sirb.Validation.Documents.BR.Validation;
using Xunit;
using Pis = Sirb.Validation.Documents.BR.Mockups.Pis;

namespace Sirb.Validation.Test;

public class PisTest
{
    [Theory]
    [InlineData("56303289843")]
    [InlineData("80589607730")]
    public void Validate_Valid(string value)
    {
        Assert.True(PisValidation.IsValid(value));
    }

    [Theory]
    [InlineData("80589607700")]
    [InlineData("27593988377")]
    public void Validate_Invalid(string value)
    {
        Assert.False(PisValidation.IsValid(value));
    }

    [Theory]
    [InlineData("53768723133")]
    public void PlaceMask(string value)
    {
        Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", PisValidation.PlaceMask(value));
    }

    [Fact]
    public void GenerateAndValidate()
    {
        string value = Pis.Generate();
        bool result = PisValidation.IsValid(value);
        Assert.True(result);
    }
}