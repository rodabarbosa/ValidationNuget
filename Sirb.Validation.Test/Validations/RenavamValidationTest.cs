using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Validations
{
    public class RenavamValidationTest
    {
        [Theory]
        [InlineData("97091043703")]
        [InlineData("197073212")]
        [InlineData("00639884962")]
        public void Validate_Valid(string value)
        {
            var isValid = RenavamValidation.IsValid(value);
            Assert.True(isValid);
        }
    }
}
