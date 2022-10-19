using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class MinasGeraisExtensionTest
    {
        [Theory]
        [InlineData("0000000000000", "000.000.000/0000")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskMg();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("0000000000000", "000.000.000/0000")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskAl();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
