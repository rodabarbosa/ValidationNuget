using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class MatoGrossoExtensionTest
    {
        [Theory]
        [InlineData("00130000019", "0013000001-9")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskMt();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("00130000019", "0013000001-9")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
