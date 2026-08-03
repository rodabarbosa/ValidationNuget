using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups;

public class CpfMockupTest
{
    [Fact(DisplayName = "Cpf.Generate should produce a value that passes validation")]
    public void GenerateAndValidate()
    {
        var value = Cpf.Generate();
        var isValid = CpfValidation.IsValid(value);
        Assert.True(isValid);
    }

    [Theory(DisplayName = "Cpf.Generate for each state should produce a CPF that passes validation and GetIssuingState returns correct state")]
    [InlineData(State.AC, "RS")]
    [InlineData(State.AL, "DF, GO, MS, TO")]
    [InlineData(State.AP, "CE, MA, PI ")]
    [InlineData(State.AM, "AC, AP, AM, PA, RO, RR")]
    [InlineData(State.BA, "PE, RN, PB, AL")]
    [InlineData(State.CE, "BA, SE")]
    [InlineData(State.DF, "MG")]
    [InlineData(State.ES, "RJ, ES")]
    [InlineData(State.GO, "SP")]
    [InlineData(State.MA, "PR, SC")]
    public void Generate_ForEveryState_ProducesValidCpfWithCorrectIssuingState(State state, string expectedState)
    {
        for (var i = 0; i < 50; i++)
        {
            var cpf = Cpf.Generate(state);
            Assert.True(CpfValidation.IsValid(cpf), $"Generated CPF '{cpf}' for state {state} should be valid");
            var issuingState = CpfValidation.GetIssuingState(cpf);
            Assert.Equal(expectedState, issuingState);
        }
    }
}
