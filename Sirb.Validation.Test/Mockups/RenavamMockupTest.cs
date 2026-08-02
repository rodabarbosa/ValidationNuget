using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class RenavamMockupTest
{
    [Fact(DisplayName = "Renavam.Generate should produce a value that passes validation")]
    public void GenerateAndValidate()
    {
        var value = Renavam.Generate();
        var isValid = RenavamValidation.IsValid(value);
        Assert.True(isValid);
    }
}
