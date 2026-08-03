using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoMinasGeraisMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Minas Gerais IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.MG);
        var isValid = InscricaoEstadualValidation.IsValid(State.MG, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Minas Gerais IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.MG);
            var isValid = InscricaoEstadualValidation.IsValid(State.MG, value);
            Assert.True(isValid, $"Generated IE '{value}' should be valid (iteration {i})");
        }
    }

    [Theory(DisplayName = "CalcultateBeforeLastWeight covers both branches (even/odd index)")]
    [InlineData(0, 1)]
    [InlineData(2, 1)]
    [InlineData(1, 2)]
    [InlineData(3, 2)]
    public void CalcultateBeforeLastWeight_ViaReflection(int index, int expected)
    {
        var method = typeof(InscricaoEstadualMG).GetMethod("CalcultateBeforeLastWeight",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { index });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "CalculateLastWeight covers both branches (index < 2 and index >= 2)")]
    [InlineData(0, 3)]
    [InlineData(1, 2)]
    [InlineData(2, 11)]
    [InlineData(5, 8)]
    public void CalculateLastWeight_ViaReflection(int index, int expected)
    {
        var method = typeof(InscricaoEstadualMG).GetMethod("CalculateLastWeight",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { index });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "ValidateSummationValue covers both branches (while loop entered/not entered)")]
    [InlineData(0, 0)]
    [InlineData(10, 0)]
    [InlineData(5, 5)]
    [InlineData(7, 3)]
    [InlineData(1, 9)]
    public void ValidateSummationValue_ViaReflection(int summationValue, int expected)
    {
        var method = typeof(InscricaoEstadualMG).GetMethod("ValidateSummationValue",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { summationValue });
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "ValidateLastDigit covers all branches (remainder 0, remainder 1, normal)")]
    [InlineData(0, 0)]
    [InlineData(11, 0)]
    [InlineData(1, 0)]
    [InlineData(12, 0)]
    [InlineData(2, 9)]
    [InlineData(10, 1)]
    public void ValidateLastDigit_ViaReflection(int summationValue, int expected)
    {
        var method = typeof(InscricaoEstadualMG).GetMethod("ValidateLastDigit",
            BindingFlags.NonPublic | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { summationValue });
        Assert.Equal(expected, result);
    }
}
