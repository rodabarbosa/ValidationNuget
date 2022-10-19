using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations
{
    public class TituloEleitorValidationTest
    {
        [Theory]
        [InlineData("470080440124")]
        [InlineData("876807870728")]
        public void Validate_Valid(string value)
        {
            var isValid = TituloEleitorValidation.IsValid(value);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("876807870700")]
        [InlineData("316816351122")]
        public void Validate_Invalid(string value)
        {
            var isValid = TituloEleitorValidation.IsValid(value);
            Assert.False(isValid);
        }
    }
}
