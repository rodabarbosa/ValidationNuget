using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class RoraimaExtensionTest
    {
        [Theory]
        [InlineData("240066281", "24006628-1")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskRr();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("240066281", "24006628-1")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
