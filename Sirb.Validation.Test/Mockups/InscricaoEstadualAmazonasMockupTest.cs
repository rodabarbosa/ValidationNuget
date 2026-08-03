using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using Sirb.Validation.Documents.BR.Validation;
using System.Reflection;
using Xunit;
using System;

namespace Sirb.Validation.Test.Mockups;

public class InscricaoEstadualAmazonasMockupTest
{
    [Fact(DisplayName = "InscricaoEstadual.Generate should produce a valid Amazonas IE")]
    public void Validate()
    {
        var value = InscricaoEstadual.Generate(State.AM);
        var isValid = InscricaoEstadualValidation.IsValid(State.AM, value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "InscricaoEstadual.Generate should produce valid Amazonas IE in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = InscricaoEstadual.Generate(State.AM);
            var isValid = InscricaoEstadualValidation.IsValid(State.AM, value);
            Assert.True(isValid, $"Generated AM IE '{value}' should be valid (iteration {i})");
        }
    }

    [Theory(DisplayName = "CalculateLastDigit private method covers all branches via reflection")]
    [InlineData(0, 0)]   // summationValue < 11 (aux = 0), aux > 1 false → return 0
    [InlineData(5, 6)]   // summationValue < 11 (aux = 5), aux > 1 true → return 11-5=6
    [InlineData(1, 0)]   // summationValue < 11 (aux = 1), aux > 1 false → return 0
    [InlineData(11, 0)]  // summationValue >= 11 (aux = 11%11=0), aux > 1 false → return 0
    [InlineData(12, 0)]  // summationValue >= 11 (aux = 12%11=1), aux > 1 false → return 0
    [InlineData(13, 9)]  // summationValue >= 11 (aux = 13%11=2), aux > 1 true → return 11-2=9
    public void CalculateLastDigit_ViaReflection(int summationValue, int expected)
    {
        var method = typeof(InscricaoEstadualAm).GetMethod("CalculateLastDigit",
            BindingFlags.NonPublic | BindingFlags.Instance);
        var instance = Activator.CreateInstance(typeof(InscricaoEstadualAm), true);
        var result = method!.Invoke(instance, new object[] { summationValue });
        Assert.Equal(expected, result);
    }
}
