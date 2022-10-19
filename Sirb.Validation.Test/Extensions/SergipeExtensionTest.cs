using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class SergipeExtensionTest
    {
        [Theory]
        [InlineData("271234563", "27123456-3")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskSe();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("271234563", "27123456-3")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
