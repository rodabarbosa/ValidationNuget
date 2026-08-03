using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using System.Reflection;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class CnpjAlfanumericoMockupTest
{
    [Fact(DisplayName = "CnpjAlfanumerico.Generate should produce a valid CNPJ")]
    public void Validate()
    {
        var value = CnpjAlfanumerico.Generate();
        var isValid = CnpjAlfanumericoValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Fact(DisplayName = "CnpjAlfanumerico.Generate should produce valid CNPJ in 2000 iterations")]
    public void Validate_Loop_2000Iterations()
    {
        for (var i = 0; i < 2000; i++)
        {
            var value = CnpjAlfanumerico.Generate();
            var isValid = CnpjAlfanumericoValidation.IsValid(value);
            Assert.True(isValid, $"Generated CNPJ '{value}' should be valid (iteration {i})");
        }
    }

    [Fact(DisplayName = "CnpjAlfanumerico.GenerateWithMask should produce masked CNPJ")]
    public void GenerateWithMask_ShouldReturnMaskedValue()
    {
        var value = CnpjAlfanumerico.GenerateWithMask();
        Assert.NotNull(value);
        Assert.Matches(@"^[A-Z0-9]{2}\.[A-Z0-9]{3}\.[A-Z0-9]{3}/[A-Z0-9]{4}-[0-9]{2}$", value);
    }

    /// <summary>
    /// Covers all three branches of IntArrayExtensions.ConvertToString:
    /// - v >= 0 && v <= 9  → '0' + v
    /// - v >= 17 && v <= 42 → (char)(v + 48)
    /// - else (fallback, line 90) → '0'
    /// </summary>
    [Theory(DisplayName = "IntArrayExtensions.ConvertToString covers all branches via reflection")]
    [InlineData(new[] { 0 }, "0")]      // branch 1: digit 0
    [InlineData(new[] { 9 }, "9")]      // branch 1: digit 9
    [InlineData(new[] { 17 }, "A")]     // branch 2: letter A (17 + 48 = 65 = 'A')
    [InlineData(new[] { 42 }, "Z")]     // branch 2: letter Z (42 + 48 = 90 = 'Z')
    [InlineData(new[] { 15 }, "0")]    // else branch: 15 is outside [0-9] and [17-42]
    [InlineData(new[] { -1 }, "0")]    // else branch: negative value
    [InlineData(new[] { 10 }, "0")]    // else branch: 10 is outside [0-9] and [17-42]
    [InlineData(new[] { 0, 17, 15 }, "0A0")] // mixed: all three branches
    public void IntArrayExtensions_ConvertToString_CoversAllBranches(int[] values, string expected)
    {
        var type = typeof(IntArrayExtensions);
        var method = type.GetMethod("ConvertToString",
            BindingFlags.Public | BindingFlags.Static);
        var result = method!.Invoke(null, new object[] { values });
        Assert.Equal(expected, result);
    }
}
