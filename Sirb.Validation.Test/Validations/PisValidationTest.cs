using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations
{
    public class PisValidationTest
    {
        [Theory]
        [InlineData("56303289843")]
        [InlineData("80589607730")]
        public void Validate_Valid(string value)
        {
            var isValid = PisValidation.IsValid(value);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("80589607700")]
        [InlineData("27593988377")]
        public void Validate_Invalid(string value)
        {
            var isValid = PisValidation.IsValid(value);
            Assert.False(isValid);
        }
    }
}
