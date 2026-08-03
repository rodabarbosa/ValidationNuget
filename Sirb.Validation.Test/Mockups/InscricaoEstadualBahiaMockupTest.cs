using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualBahiaMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Bahia IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.BA);
        var isValid = InscricaoEstadualValidation.IsValid(State.BA, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Bahia IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.BA);
            var isValid = InscricaoEstadualValidation.IsValid(State.BA, value);
            Assert.True(isValid, $"Generated IE '{value}' should be valid (iteration {i})");
        }
    }

    /// <summary>
    /// Covers GetModuloValue branches:
    /// - length == 9 → digitIndex == 1 (checks values[1] against {6,7,9})
    /// - length == 8 → digitIndex == 0 (checks values[0] against {6,7,9})
    /// - validationDigits.Contains → 11, else → 10
    /// </summary>
    [Theory(DisplayName = "GetModuloValue covers all branches via reflection")]
    [InlineData(new[] { 1, 6 }, 9, 11)]   // length 9, digitIndex=1, values[1]=6 in {6,7,9} → 11
    [InlineData(new[] { 1, 0 }, 9, 10)]   // length 9, digitIndex=1, values[1]=0 not in {6,7,9} → 10
    [InlineData(new[] { 6, 0 }, 8, 11)]   // length 8, digitIndex=0, values[0]=6 in {6,7,9} → 11
    [InlineData(new[] { 1, 0 }, 8, 10)]   // length 8, digitIndex=0, values[0]=1 not in {6,7,9} → 10
    [InlineData(new[] { 1, 7 }, 9, 11)]   // values[1]=7 in {6,7,9} → 11
    [InlineData(new[] { 1, 9 }, 9, 11)]   // values[1]=9 in {6,7,9} → 11
    public void GetModuloValue_ViaReflection(int[] values, int length, int expected)
    {
        var method = typeof(InscricaoEstadualBa).GetMethod("GetModuloValue",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { values, length });
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Covers GetDigitValue branches:
    /// - remainder == 0 → return 0 (first condition of ||)
    /// - remainder != 0 && moduleValue == 11 && remainder == 1 → return 0 (second condition of ||)
    /// - remainder != 0 && !(moduleValue == 11 && remainder == 1) → return moduleValue - remainder
    /// </summary>
    [Theory(DisplayName = "GetDigitValue covers all branches via reflection")]
    [InlineData(0, 11, 0)]    // remainder=0 → first condition true → 0
    [InlineData(11, 11, 0)]   // remainder=0 → first condition true → 0
    [InlineData(1, 11, 0)]    // remainder=1, moduleValue=11 → second condition true → 0
    [InlineData(12, 11, 0)]   // remainder=1, moduleValue=11 → second condition true → 0
    [InlineData(5, 10, 5)]    // remainder=5, moduleValue=10 → false → 10-5=5
    [InlineData(3, 11, 8)]    // remainder=3, moduleValue=11 → false → 11-3=8
    [InlineData(7, 10, 3)]    // remainder=7, moduleValue=10 → false → 10-7=3
    public void GetDigitValue_ViaReflection(int summantionValue, int moduleValue, int expected)
    {
        var method = typeof(InscricaoEstadualBa).GetMethod("GetDigitValue",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { summantionValue, moduleValue });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "CalculateBeforeLastWeight covers both length branches via reflection")]
    [InlineData(0, 8, 7)]    // length 8 → value=7 → 7-0=7
    [InlineData(0, 9, 8)]    // length 9 → value=8 → 8-0=8
    [InlineData(3, 8, 4)]    // length 8 → 7-3=4
    [InlineData(3, 9, 5)]    // length 9 → 8-3=5
    public void CalculateBeforeLastWeight_ViaReflection(int index, int length, int expected)
    {
        var method = typeof(InscricaoEstadualBa).GetMethod("CalculateBeforeLastWeight",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { index, length });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "CalculateLastWeight covers both length branches via reflection")]
    [InlineData(0, 8, 8)]    // length 8 → value=8 → 8-0=8
    [InlineData(0, 9, 9)]    // length 9 → value=9 → 9-0=9
    [InlineData(3, 8, 5)]    // length 8 → 8-3=5
    [InlineData(3, 9, 6)]    // length 9 → 9-3=6
    public void CalculateLastWeight_ViaReflection(int index, int length, int expected)
    {
        var method = typeof(InscricaoEstadualBa).GetMethod("CalculateLastWeight",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { index, length });
        Assert.Equal(expected, result);
    }
}
