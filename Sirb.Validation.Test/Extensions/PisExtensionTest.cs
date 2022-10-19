using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class PisExtensionTest
    {
        [Theory]
        [InlineData("56303289843")]
        [InlineData("80589607730")]
        public void Validate_Valid(string value)
        {
            var isValid = value.IsPisValid();
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("80589607700")]
        [InlineData("27593988377")]
        public void Validate_Invalid(string value)
        {
            var isValid = value.IsPisValid();
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("53768723133")]
        public void PlaceMask(string value)
        {
            var masked = value.PlacePisMask();
            Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", masked);
        }
    }
}
