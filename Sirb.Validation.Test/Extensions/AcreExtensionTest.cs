using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class AcreExtensionTest
    {
        [Theory]
        [InlineData("0100482300112", "01.004.823/001-12")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskAc();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("0100482300112", "01.004.823/001-12")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskAl();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
