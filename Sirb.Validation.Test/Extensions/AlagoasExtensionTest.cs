using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class AlagoasExtensionTest
    {
        [Theory]
        [InlineData("123456789", "12345678-9")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskAl();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("123456789", "12345678-9")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskAp();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
