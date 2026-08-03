using Sirb.Validation.Extensions;
using Xunit;

namespace Sirb.Validation.Test.Extensions;

public class StringExtensionTest
{
    [Theory(DisplayName = "OnlyNumbers should extract only digit characters from input")]
    [InlineData("0100482300112", "01.004.823/001-12")]
    public void OnlyNumbers_Valid(string expected, string value)
    {
        var newValue = value.OnlyNumbers();
        Assert.Equal(expected, newValue);
    }

    [Theory(DisplayName = "NoNumbers should remove all digit characters from input")]
    [InlineData("P../-", "P01.004.823/001-12")]
    public void NoNumbers_Valid(string expected, string value)
    {
        var noNumbersValue = value.NoNumbers();
        Assert.Equal(expected, noNumbersValue);
    }

    [Theory(DisplayName = "ToCapitalizeAll should capitalize all words in input")]
    [InlineData("Test Test", "test test")]
    public void ToCapitalizeAll_Valid(string expected, string value)
    {
        var newValue = value.ToCapitalizeAll();
        Assert.Equal(expected, newValue);
    }

    [Theory(DisplayName = "ToCapitalize should capitalize first letter of each word in input")]
    [InlineData("Test test", "test test")]
    [InlineData("", "")]
    public void ToCapitalize_Valid(string expected, string value)
    {
        var newValue = value.ToCapitalize();
        Assert.Equal(expected, newValue);
    }

    [Theory(DisplayName = "RemoveLatinCharacters should remove accented characters from input")]
    [InlineData("avaliação", "avaliacao")]
    public void RemoveLatin_Valid(string value, string expected)
    {
        var newValue = value.RemoveLatinCharacters();
        Assert.Equal(expected, newValue);
    }

    [Fact(DisplayName = "RemoveMask should return null for null input")]
    public void RemoveMask_Null_ReturnsNull()
    {
        var result = ((string)null).RemoveMask();
        Assert.Null(result);
    }

    [Theory(DisplayName = "RemoveMask should return empty string for empty input")]
    [InlineData("")]
    public void RemoveMask_Empty_ReturnsEmpty(string value)
    {
        var result = value.RemoveMask();
        Assert.Equal(string.Empty, result);
    }

    [Theory(DisplayName = "RemoveMask should return only numbers for non-empty input")]
    [InlineData("12.345.678-9", "123456789")]
    [InlineData("abc123", "123")]
    public void RemoveMask_Valid_ReturnsOnlyNumbers(string value, string expected)
    {
        var result = value.RemoveMask();
        Assert.Equal(expected, result);
    }
}
