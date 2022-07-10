using Sirb.Documents.BR.Validation;
using Xunit;

namespace Sirb.Test;

public class RenavamTest
{
    [Theory]
    [InlineData("97091043703")]
    [InlineData("197073212")]
    [InlineData("00639884962")]
    public void Validate_Valid(string value)
    {
        Assert.True(Renavam.IsValid(value));
    }

    [Fact]
    public void GenerateAndValidate()
    {
        string value = Documents.BR.Mockups.Renavam.Generate();
        bool result = Renavam.IsValid(value);
        Assert.True(result);
    }
}