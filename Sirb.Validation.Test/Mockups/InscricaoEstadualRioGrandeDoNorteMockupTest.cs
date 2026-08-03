using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualRioGrandeDoNorteMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Rio Grande do Norte IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.RN);
        var isValid = InscricaoEstadualValidation.IsValid(State.RN, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Rio Grande do Norte IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.RN);
            var isValid = InscricaoEstadualValidation.IsValid(State.RN, value);
            Assert.True(isValid, $"Generated IE '{value}' should be valid (iteration {i})");
        }
    }

    /// <summary>
    /// Covers GetRandomLength branches: random.Next(2) == 0 → returns 6; == 1 → returns 7.
    /// Uses multiple seeds to ensure both branches are exercised.
    /// </summary>
    [Fact(DisplayName = "GetRandomLength covers both branches via reflection")]
    public void GetRandomLength_ViaReflection_CoversBothBranches()
    {
        var method = typeof(InscricaoEstadualRn).GetMethod("GetRandomLength",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualRn), true);

        var results = new HashSet<int>();
        for (var seed = 0; seed < 100; seed++)
        {
            var random = new Random(seed);
            var result = (int)method!.Invoke(instance, new object[] { random });
            results.Add(result);
        }

        Assert.Contains(6, results);
        Assert.Contains(7, results);
    }

    /// <summary>
    /// Covers TotalBase branches: length == 6 → 18; length == 7 → 20.
    /// </summary>
    [Theory(DisplayName = "TotalBase covers both branches via reflection")]
    [InlineData(6, 18)]
    [InlineData(7, 20)]
    public void TotalBase_ViaReflection(int length, int expected)
    {
        var method = typeof(InscricaoEstadualRn).GetMethod("TotalBase",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualRn), true);
        var result = method!.Invoke(instance, new object[] { length });
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Covers CalculateLastDigit branches:
    /// - remainder == 10 → return 0
    /// - remainder != 10 → return remainder
    /// </summary>
    [Theory(DisplayName = "CalculateLastDigit covers both branches via reflection")]
    [InlineData(1, 0)]    // 1*10=10, 10%11=10 → remainder == 10 → 0
    [InlineData(12, 0)]   // 12*10=120, 120%11=10 → remainder == 10 → 0
    [InlineData(2, 9)]    // 2*10=20, 20%11=9 → remainder != 10 → 9
    [InlineData(0, 0)]    // 0*10=0, 0%11=0 → remainder != 10 → 0
    [InlineData(3, 8)]    // 3*10=30, 30%11=8 → remainder != 10 → 8
    public void CalculateLastDigit_ViaReflection(int summationValue, int expected)
    {
        var method = typeof(InscricaoEstadualRn).GetMethod("CalculateLastDigit",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualRn), true);
        var result = method!.Invoke(instance, new object[] { summationValue });
        Assert.Equal(expected, result);
    }
}
