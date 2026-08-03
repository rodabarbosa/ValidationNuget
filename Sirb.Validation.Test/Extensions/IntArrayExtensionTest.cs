using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class IntArrayExtensionTest
{
    [Fact(DisplayName = "ConvertToString should return empty string for empty array")]
    public void ConvertToString_EmptyArray_ReturnsEmptyString()
    {
        var result = new int[0].ConvertToString();
        Assert.Equal(string.Empty, result);
    }

    [Fact(DisplayName = "ConvertToString should return single digit as string")]
    public void ConvertToString_SingleDigit_ReturnsDigitString()
    {
        var result = new[] { 5 }.ConvertToString();
        Assert.Equal("5", result);
    }

    [Theory(DisplayName = "ConvertToString should concatenate all digits")]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, "0123456789")]
    [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, "9876543210")]
    [InlineData(new[] { 0 }, "0")]
    [InlineData(new[] { 1, 0, 0, 4, 8, 2, 3, 0, 0, 1, 1, 2 }, "100482300112")]
    [InlineData(new[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }, "33333333333")]
    public void ConvertToString_MultipleDigits_ReturnsConcatenatedString(int[] values, string expected)
    {
        var result = values.ConvertToString();
        Assert.Equal(expected, result);
    }
}
