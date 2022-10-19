using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class CnpjMockupTest
    {
        [Fact]
        public void GenerateAndValidate()
        {
            var value = Cnpj.Generate();
            var isValid = CnpjValidation.IsValid(value);
            Assert.True(isValid);
        }
    }
}
