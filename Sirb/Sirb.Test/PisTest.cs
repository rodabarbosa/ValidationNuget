using Sirb.Documents.BR.Validation;
using Xunit;

namespace Sirb.Test;

public class PisTest
{
    [Theory]
    [InlineData("56303289843")]
    [InlineData("80589607730")]
    public void Validate_Valid(string value)
    {
        Assert.True(Pis.IsValid(value));
    }

    [Theory]
    [InlineData("80589607700")]
    [InlineData("27593988377")]
    public void Validate_Invalid(string value)
    {
        Assert.False(Pis.IsValid(value));
    }

    [Theory]
    [InlineData("53768723133")]
    public void PlaceMask(string value)
    {
        Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", Pis.PlaceMask(value));
    }

    [Fact]
    public void GenerateAndValidate()
    {
        string value = Documents.BR.Mockups.Pis.Generate();
        bool result = Pis.IsValid(value);
        Assert.True(result);
    }
}
