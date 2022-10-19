using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions
{
    public class ParanaExtensionTest
    {
        [Theory]
        [InlineData("0000000000", "00000000-00")]
        [InlineData("2844513847", "28445138-47")]
        [InlineData("3606810252", "36068102-52")]
        [InlineData("4046398039", "40463980-39")]
        [InlineData("9188059667", "91880596-67")]
        [InlineData("6991937631", "69919376-31")]
        [InlineData("7668077557", "76680775-57")]
        [InlineData("4850974301", "48509743-01")]
        [InlineData("0344257795", "03442577-95")]
        [InlineData("6408193166", "64081931-66")]
        [InlineData("3896200177", "38962001-77")]
        public void InscricaoEstadualMask_Valid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskPr();
            Assert.Equal(expected, maskedValue);
        }

        [Theory]
        [InlineData("0000000000", "00000000-00")]
        public void InscricaoEstadualMask_Invalid(string value, string expected)
        {
            var maskedValue = value.InscricaoEstadualMaskEs();
            Assert.NotEqual(expected, maskedValue);
        }
    }
}
