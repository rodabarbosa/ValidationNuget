using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using System;
using Xunit;

namespace Sirb.Validation.Test.Validations;

public class CpfValidationTest
{
    [Theory(DisplayName = "IsValid should return true for valid CPF")]
    [InlineData("715.470.830-18")]
    [InlineData("115.327.120-65")]
    public void Validate_Valid(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for invalid CPF")]
    [InlineData("115.327.120-60")]
    [InlineData("715.470.830-33")]
    [InlineData("000.000.000-00")]
    public void Validate_Invalid(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for null, empty, and whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_NullEmptyWhitespace_ReturnsFalse(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Theory(DisplayName = "IsValid should return false for CPF with wrong length")]
    [InlineData("1234567890")]
    [InlineData("123456789012")]
    public void Validate_WrongLength_ReturnsFalse(string value)
    {
        var isValid = CpfValidation.IsValid(value);
        Assert.False(isValid);
    }

    [Fact(DisplayName = "IsValid should cover GetModulusForDigitComparison value==10 branch")]
    public void Validate_CoversModulusValueTenBranch()
    {
        // CPF "10000000108" triggers sums[0] = 12, 12*10%11 = 10 => value = 0 (the value==10 branch)
        var isValid = CpfValidation.IsValid("10000000108");
        Assert.True(isValid);
    }

    [Theory(DisplayName = "PlaceMask should return null for null, empty, or whitespace input")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PlaceMask_NullEmptyWhitespace_ReturnsNull(string value)
    {
        var result = CpfValidation.PlaceMask(value);
        Assert.Null(result);
    }

    [Theory(DisplayName = "PlaceMask should apply CPF mask to valid input")]
    [InlineData("12345678901", "123.456.789-01")]
    [InlineData("71547083018", "715.470.830-18")]
    public void PlaceMask_ValidInput_ReturnsMasked(string input, string expected)
    {
        var result = CpfValidation.PlaceMask(input);
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "GetIssuingState should throw InvalidOperationException for invalid CPF")]
    public void GetIssuingState_InvalidCpf_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => CpfValidation.GetIssuingState("12345678901"));
    }

    [Fact(DisplayName = "GetIssuingState should return RS for CPF with 9th digit 0")]
    public void GetIssuingState_DigitZero_ReturnsRS()
    {
        var cpf = Cpf.Generate(State.AC);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("RS", result);
    }

    [Fact(DisplayName = "GetIssuingState should return DF, GO, MS, TO for CPF with 9th digit 1")]
    public void GetIssuingState_DigitOne_ReturnsDFGO_MSTO()
    {
        var cpf = Cpf.Generate(State.AL);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("DF, GO, MS, TO", result);
    }

    [Fact(DisplayName = "GetIssuingState should return AC, AP, AM, PA, RO, RR for CPF with 9th digit 2")]
    public void GetIssuingState_DigitTwo_ReturnsACAPAM_PORR()
    {
        var cpf = Cpf.Generate(State.AM);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("AC, AP, AM, PA, RO, RR", result);
    }

    [Fact(DisplayName = "GetIssuingState should return CE, MA, PI for CPF with 9th digit 3")]
    public void GetIssuingState_DigitThree_ReturnsCEMAPI()
    {
        var cpf = Cpf.Generate(State.AP);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("CE, MA, PI ", result);
    }

    [Fact(DisplayName = "GetIssuingState should return PE, RN, PB, AL for CPF with 9th digit 4")]
    public void GetIssuingState_DigitFour_ReturnsPERNPBAL()
    {
        var cpf = Cpf.Generate(State.BA);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("PE, RN, PB, AL", result);
    }

    [Fact(DisplayName = "GetIssuingState should return BA, SE for CPF with 9th digit 5")]
    public void GetIssuingState_DigitFive_ReturnsBASE()
    {
        var cpf = Cpf.Generate(State.CE);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("BA, SE", result);
    }

    [Fact(DisplayName = "GetIssuingState should return MG for CPF with 9th digit 6")]
    public void GetIssuingState_DigitSix_ReturnsMG()
    {
        var cpf = Cpf.Generate(State.DF);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("MG", result);
    }

    [Fact(DisplayName = "GetIssuingState should return RJ, ES for CPF with 9th digit 7")]
    public void GetIssuingState_DigitSeven_ReturnsRJES()
    {
        var cpf = Cpf.Generate(State.ES);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("RJ, ES", result);
    }

    [Fact(DisplayName = "GetIssuingState should return SP for CPF with 9th digit 8")]
    public void GetIssuingState_DigitEight_ReturnsSP()
    {
        var cpf = Cpf.Generate(State.GO);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("SP", result);
    }

    [Fact(DisplayName = "GetIssuingState should return PR, SC for CPF with 9th digit 9")]
    public void GetIssuingState_DigitNine_ReturnsPRSC()
    {
        var cpf = Cpf.Generate(State.MA);
        var result = CpfValidation.GetIssuingState(cpf);
        Assert.Equal("PR, SC", result);
    }
}
