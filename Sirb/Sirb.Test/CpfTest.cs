using Sirb.Documents.BR.Validation;
using Sirb.Extensions;
using Xunit;

namespace Sirb.Test;

public class CpfTest
{
    [Theory]
    [InlineData("715.470.830-18")]
    [InlineData("115.327.120-65")]
    public void Validate_Valid(string value)
    {
        Assert.True(Cpf.IsValid(value));
    }

    [Theory]
    [InlineData("115.327.120-60")]
    [InlineData("715.470.830-33")]
    public void Validate_Invalid(string value)
    {
        Assert.False(Cpf.IsValid(value));
    }

    [Theory]
    [InlineData("71547083018")]
    public void PlaceMask(string value)
    {
        Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", Cpf.PlaceMask(value));
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
        string value = Documents.BR.Mockups.Cpf.Generate();
        bool result = Cpf.IsValid(value);
        Assert.True(result);
    }
}
