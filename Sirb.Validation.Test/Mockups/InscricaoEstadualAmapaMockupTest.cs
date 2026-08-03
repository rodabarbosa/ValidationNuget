using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAmapaMockupTest
{
    [Theory(DisplayName = "InscricaoEstadual.Generate should produce a valid Amapá IE")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void Validate(int index)
    {
        System.Diagnostics.Debug.WriteLine($"Debug Validation {index}");
        string value = InscricaoEstadual.Generate(State.AP);
        bool isValid = InscricaoEstadualValidation.IsValid(State.AP, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Amapá IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.AP);
            var isValid = InscricaoEstadualValidation.IsValid(State.AP, value);
            Assert.True(isValid, $"Generated AP IE '{value}' should be valid (iteration {i})");
        }
    }

    [Theory(DisplayName = "CalculateLastDigit private method covers all branches via reflection")]
    [InlineData(new[] { 0, 3, 0, 1, 7, 0, 0, 1 }, 85, 5)]
    [InlineData(new[] { 0, 3, 0, 0, 0, 0, 0, 1 }, 33, 6)]
    [InlineData(new[] { 0, 3, 0, 0, 0, 0, 0, 0 }, 1, 0)]
    [InlineData(new[] { 0, 3, 0, 0, 0, 0, 0, 0 }, 0, 0)]
    [InlineData(new[] { 0, 3, 0, 0, 0, 0, 0, 0 }, 2, 9)]
    public void CalculateLastDigit_ViaReflection(int[] eightDigitValue, int summationValue, int expected)
    {
        var method = typeof(InscricaoEstadualAp).GetMethod("CalculateLastDigit",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { eightDigitValue, summationValue });
        Assert.Equal(expected, result);
    }
}
