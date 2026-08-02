using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class TituloEleitorMockupTest
{
    [Theory(DisplayName = "TituloEleitor.Generate should produce a value that passes validation")]
    [InlineData(10)]
    public void GenerateAndValidate(int retry)
    {
        for (var i = 0; i < retry; i++)
        {
            var value = TituloEleitor.Generate();
            var isValid = value.IsTituloEleitorValid();
            Assert.True(isValid);
        }
    }
}
