using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class ParaExtensionTest
    {
        [Theory]
        [InlineData("159999995", "15-999999-5")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskPa();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("159999995", "15-999999-5")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
