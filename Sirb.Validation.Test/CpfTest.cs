using Sirb.Validation.Documents.BR.Validation;
using Sirb.Validation.Extensions;
using Xunit;
using Cpf = Sirb.Validation.Documents.BR.Mockups.Cpf;

namespace Sirb.Validation.Test;

public class CpfTest
{
    [Theory]
    [InlineData("715.470.830-18")]
    [InlineData("115.327.120-65")]
    public void Validate_Valid(string value)
    {
        Assert.True(CpfValidation.IsValid(value));
    }

    [Theory]
    [InlineData("115.327.120-60")]
    [InlineData("715.470.830-33")]
    public void Validate_Invalid(string value)
    {
        Assert.False(CpfValidation.IsValid(value));
    }

    [Theory]
    [InlineData("71547083018")]
    public void PlaceMask(string value)
    {
        Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", CpfValidation.PlaceMask(value));
    }

    [Theory]
    [InlineData("715.470.830-18")]
    public void RemoveMask(string value)
    {
        string aux = value.OnlyNumbers();
        Assert.True(long.TryParse(aux, out long returnValue));
    }

    [Fact]
    public void GenerateAndValidate()
    {
        string value = Cpf.Generate();
        bool result = CpfValidation.IsValid(value);
        Assert.True(result);
    }
}
