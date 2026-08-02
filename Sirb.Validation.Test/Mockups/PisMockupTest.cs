using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class PisMockupTest
{
    [Fact(DisplayName = "Pis.Generate should produce a value that passes validation")]
    public void GenerateAndValidate()
    {
        var value = Pis.Generate();
        var isValid = PisValidation.IsValid(value);
        Assert.True(isValid);
    }
}
