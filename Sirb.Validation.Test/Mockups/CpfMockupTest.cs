using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class CpfMockupTest
{
    [Fact(DisplayName = "Cpf.Generate should produce a value that passes validation")]
    public void GenerateAndValidate()
    {
        var value = Cpf.Generate();
        var isValid = CpfValidation.IsValid(value);
        Assert.True(isValid);
    }
}
