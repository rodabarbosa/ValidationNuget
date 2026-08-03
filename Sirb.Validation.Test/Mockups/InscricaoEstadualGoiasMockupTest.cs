using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualGoiasMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Goiás IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.GO);
        var isValid = InscricaoEstadualValidation.IsValid(State.GO, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Goiás IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.GO);
            var isValid = InscricaoEstadualValidation.IsValid(State.GO, value);
            Assert.True(isValid, $"Generated GO IE '{value}' should be valid (iteration {i})");
        }
    }

    [Theory(DisplayName = "CalculateLastDigit private method covers all branches via reflection")]
    [InlineData(0, "10103105", 0)]
    [InlineData(1, "10103105", 1)]
    [InlineData(1, "10000000", 0)]
    [InlineData(2, "10000000", 9)]
    [InlineData(10, "10000000", 1)]
    public void CalculateLastDigit_ViaReflection(int summationValue, string partialGeneratedNumber, int expected)
    {
        var method = typeof(InscricaoEstadualGO).GetMethod("CalculateLastDigit",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { summationValue, partialGeneratedNumber });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "GenerateSecondDigit covers all switch cases via reflection")]
    [InlineData(1, 0, 0)]
    [InlineData(5, 1, 8)]
    [InlineData(0, 5, 40)]
    public void GenerateSecondDigit_ViaReflection(int randomNextValue, int expectedAddedDigit, int expectedReturnValue)
    {
        var method = typeof(InscricaoEstadualGO).GetMethod("GenerateSecondDigit",
            BindingFlags.NonPublic | BindingFlags.Static);
        var list = new List<int>();
        var random = new Random(randomNextValue);
        var result = method!.Invoke(null, new object[] { list, random });
        Assert.Equal(expectedReturnValue, result);
        Assert.Equal(expectedAddedDigit, list[list.Count - 1]);
    }
}
