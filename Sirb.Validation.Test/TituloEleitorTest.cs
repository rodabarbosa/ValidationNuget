using Sirb.Validation.Documents.BR.Validation;
using Xunit;
using TituloEleitor = Sirb.Validation.Documents.BR.Mockups.TituloEleitor;

namespace Sirb.Validation.Test;

public class TituloEleitorTest
{
    [Theory]
    [InlineData("470080440124")]
    [InlineData("876807870728")]
    public void Validate_Valid(string value)
    {
        Assert.True(TituloEleitorValidation.IsValid(value));
    }

    [Theory]
    [InlineData("876807870700")]
    [InlineData("316816351122")]
    public void Validate_Invalid(string value)
    {
        Assert.False(TituloEleitorValidation.IsValid(value));
    }

    [Theory]
    [InlineData("475452000132")]
    public void PlaceMask(string value)
    {
        Assert.Matches(@"(\d{4}).(\d{4}).(\d{4})", TituloEleitorValidation.PlaceMask(value));
    }

    [Fact]
    public void GenerateAndValidate()
    {
        string value = TituloEleitor.Generate();
        bool result = TituloEleitorValidation.IsValid(value);
        Assert.True(result);
    }
}
