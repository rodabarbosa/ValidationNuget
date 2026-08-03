using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualSaoPauloMockupTest
{
    [Theory(DisplayName = "InscricaoEstadual.Generate should produce a valid São Paulo IE")]
    [InlineData(2000)]
    public void Validate(int retry)
    {
        for (var i = 0; i < retry; i++)
        {
            var value = InscricaoEstadual.Generate(State.SP);
            var isValid = InscricaoEstadualValidation.IsValid(State.SP, value);
            Assert.True(isValid);
        }
    }

    [Theory(DisplayName = "InscricaoEstadual.Generate should produce a valid São Paulo IE with P prefix")]
    [InlineData("P-01100424.3/002")]
    public void ValidateWithP(string value)
    {
        var isValid = InscricaoEstadualValidation.IsValid(State.SP, value);
        Assert.True(isValid);
    }

    /// <summary>
    /// Covers CalculateBeforeLastWeight branches:
    /// - index == 0 → return 1
    /// - index > 6 → return (3 + index)
    /// - else → return (2 + index)
    /// </summary>
    [Theory(DisplayName = "CalculateBeforeLastWeight covers all branches via reflection")]
    [InlineData(0, 1)]    // index == 0 → 1
    [InlineData(7, 10)]   // index > 6 → 3 + 7 = 10
    [InlineData(8, 11)]   // index > 6 → 3 + 8 = 11
    [InlineData(1, 3)]    // else → 2 + 1 = 3
    [InlineData(5, 7)]    // else → 2 + 5 = 7
    [InlineData(6, 8)]    // else (index == 6, not > 6) → 2 + 6 = 8
    public void CalculateBeforeLastWeight_ViaReflection(int index, int expected)
    {
        var method = typeof(InscricaoEstadualSP).GetMethod("CalculateBeforeLastWeight",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualSP), true);
        var result = method!.Invoke(instance, new object[] { index });
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Covers CalculateLastDigitWeight branches:
    /// - index <= 2 → value = 2 → return 2 - index + 2
    /// - index > 2 → value = 11 → return 11 - index + 2
    /// </summary>
    [Theory(DisplayName = "CalculateLastDigitWeight covers both branches via reflection")]
    [InlineData(1, 3)]   // index <= 2 → 2 - 1 + 2 = 3
    [InlineData(2, 2)]   // index <= 2 → 2 - 2 + 2 = 2
    [InlineData(3, 10)]  // index > 2 → 11 - 3 + 2 = 10
    [InlineData(11, 2)]  // index > 2 → 11 - 11 + 2 = 2
    public void CalculateLastDigitWeight_ViaReflection(int index, int expected)
    {
        var method = typeof(InscricaoEstadualSP).GetMethod("CalculateLastDigitWeight",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualSP), true);
        var result = method!.Invoke(instance, new object[] { index });
        Assert.Equal(expected, result);
    }
}
