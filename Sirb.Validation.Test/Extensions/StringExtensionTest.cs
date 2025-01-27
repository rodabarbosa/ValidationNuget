namespace Sirb.Validation.Test.Extensions;

public class StringExtensionTest
{
    [Theory]
    [InlineData("0100482300112", "01.004.823/001-12")]
    public void OnlyNumbers_Valid(string expected, string value)
    {
        var newValue = value.OnlyNumbers();
        Assert.Equal(expected, newValue);
    }

    [Theory]
    [InlineData("P../-", "P01.004.823/001-12")]
    public void NoNumbers_Valid(string expected, string value)
    {
        var noNumbersValue = value.NoNumbers();
        Assert.Equal(expected, noNumbersValue);
    }

    [Theory]
    [InlineData("Test Test", "test test")]
    public void ToCapitalizeAll_Valid(string expected, string value)
    {
        var newValue = value.ToCapitalizeAll();
        Assert.Equal(expected, newValue);
    }

    [Theory]
    [InlineData("Test test", "test test")]
    [InlineData("", "")]
    public void ToCapitalize_Valid(string expected, string value)
    {
        var newValue = value.ToCapitalize();
        Assert.Equal(expected, newValue);
    }

    [Theory]
    [InlineData("avaliação", "avaliacao")]
    public void RemoveLatin_Valid(string value, string expected)
    {
        var newValue = value.RemoveLatinCharacters();
        Assert.Equal(expected, newValue);
    }
}