using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Extensions;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class TituloEleitorMockupTest
{
    [Theory(DisplayName = "TituloEleitor.Generate should produce a value that passes validation")]
    [InlineData(500)]
    public void GenerateAndValidate(int retry)
    {
        for (var i = 0; i < retry; i++)
        {
            var value = TituloEleitor.Generate();
            var isValid = value.IsTituloEleitorValid();
            Assert.True(isValid);
        }
    }

    /// <summary>
    /// Covers both branches of GetDigitValue:
    /// - remainder > 9 (i.e. remainder == 10) → return 0
    /// - remainder <= 9 → return remainder
    /// </summary>
    [Theory(DisplayName = "GetDigitValue private method covers both branches via reflection")]
    [InlineData(10, 0)]   // 10 % 11 = 10 > 9 → 0
    [InlineData(21, 0)]   // 21 % 11 = 10 > 9 → 0
    [InlineData(5, 5)]    // 5 % 11 = 5 <= 9 → 5
    [InlineData(0, 0)]    // 0 % 11 = 0 <= 9 → 0
    [InlineData(9, 9)]    // 9 % 11 = 9 <= 9 → 9
    [InlineData(11, 0)]   // 11 % 11 = 0 <= 9 → 0
    public void GetDigitValue_ViaReflection(int valueSummation, int expected)
    {
        var method = typeof(TituloEleitor).GetMethod("GetDigitValue",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { valueSummation });
        Assert.Equal(expected, result);
    }
}
