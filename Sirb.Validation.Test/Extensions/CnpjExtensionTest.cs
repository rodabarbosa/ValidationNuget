using Sirb.Validation.Exceptions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class CnpjExtensionTest
    {
        [Theory]
        [InlineData("29373908000122")]
        public void PlaceMask(string value)
        {
            var valueMasked = value.PlaceCnpjMask();
            Assert.Matches(@"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})", valueMasked);
        }

        [Theory]
        [InlineData("29373908000122")]
        public void Validate(string value)
        {
            var isValid = value.IsCnpjValid();
            Assert.True(isValid);
        }
    }
}
