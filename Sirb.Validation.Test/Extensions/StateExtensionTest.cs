using Sirb.Validation.Documents.BR.Enumeration;

namespace Sirb.Validation.Test.Extensions;

public class StateExtensionTest
{
    [Theory]
    [InlineData(State.CE, 3)]
    [InlineData(State.MA, 3)]
    [InlineData(State.PI, 3)]
    [InlineData(State.MG, 6)]
    [InlineData(State.ES, 7)]
    [InlineData(State.RJ, 7)]
    [InlineData(State.AL, 4)]
    [InlineData(State.PB, 4)]
    [InlineData(State.PE, 4)]
    [InlineData(State.RN, 4)]
    [InlineData(State.AC, 2)]
    [InlineData(State.AP, 2)]
    [InlineData(State.AM, 2)]
    [InlineData(State.PA, 2)]
    [InlineData(State.RO, 2)]
    [InlineData(State.RR, 2)]
    [InlineData(State.RS, 0)]
    [InlineData(State.BA, 5)]
    [InlineData(State.SE, 5)]
    [InlineData(State.PR, 9)]
    [InlineData(State.SC, 9)]
    [InlineData(State.SP, 8)]
    [InlineData(State.DF, 1)]
    [InlineData(State.GO, 1)]
    [InlineData(State.MS, 1)]
    [InlineData(State.TO, 1)]
    public void GetValue_Valid(State state, int expected)
    {
        var value = state.GetStateValue();
        Assert.Equal(expected, value);
    }
}