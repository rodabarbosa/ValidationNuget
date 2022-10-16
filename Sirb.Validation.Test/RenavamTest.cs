using Sirb.Validation.Documents.BR.Validation;
using Xunit;
using Renavam = Sirb.Validation.Documents.BR.Mockups.Renavam;

namespace Sirb.Validation.Test
{
    public class RenavamTest
    {
        [Theory]
        [InlineData("97091043703")]
        [InlineData("197073212")]
        [InlineData("00639884962")]
        public void Validate_Valid(string value)
        {
            Assert.True(RenavamValidation.IsValid(value));
        }

        [Fact]
        public void GenerateAndValidate()
        {
            var value = Renavam.Generate();
            var result = RenavamValidation.IsValid(value);
            Assert.True(result);
        }
    }
}
