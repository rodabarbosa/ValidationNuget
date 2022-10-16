using Sirb.Validation.Documents.BR.Validation;
using Xunit;
using Cnpj = Sirb.Validation.Documents.BR.Mockups.Cnpj;

namespace Sirb.Validation.Test
{
    public class CnpjTest
    {
        [Theory]
        [InlineData("49.616.903/0001-90")]
        [InlineData("72.923.755/0001-79")]
        public void Validate_Valid(string value)
        {
            Assert.True(CnpjValidation.IsValid(value));
        }

        [Theory]
        [InlineData("49.616.903/0001-00")]
        [InlineData("72.923.755/0001-70")]
        public void Validate_Invalid(string value)
        {
            Assert.False(CnpjValidation.IsValid(value));
        }

        [Theory]
        [InlineData("29373908000122")]
        public void PlaceMask(string value)
        {
            Assert.Matches(@"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})", CnpjValidation.PlaceMask(value));
        }

        [Fact]
        public void GenerateAndValidate()
        {
            var value = Cnpj.Generate();
            Assert.True(CnpjValidation.IsValid(value));
        }
    }
}
