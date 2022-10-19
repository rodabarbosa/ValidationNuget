using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class PernambucoExtensionTest
    {
        [Theory]
        [InlineData("032141840", "0321418-40")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskPe();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("032141840", "0321418-40")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
