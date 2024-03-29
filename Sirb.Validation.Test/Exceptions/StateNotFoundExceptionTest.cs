using Sirb.Validation.Exceptions;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Sirb.Validation.Test.Exceptions;

public class StateNotFoundExceptionTest
{
    private const string ExpectedMessage = "State not found";

    [Fact]
    public void NotFoundException_Should_Be_Created()
    {
        var exception = new StateNotFoundException();
        Assert.NotNull(exception);
    }

    [Fact]
    public void NotFoundException_Should_Have_Correct_Inner_Exception()
    {
        var expectedInnerException = new Exception();
        var exception = new StateNotFoundException(expectedInnerException);

        Assert.Equal(expectedInnerException, exception.InnerException);
    }

    [Fact]
    public void NotFoundException_Should_Have_Correct_Message()
    {
        var exception = new StateNotFoundException(ExpectedMessage);

        Assert.Equal(ExpectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(true, "Exception message")]
    [InlineData(false, "Exception message")]
    [InlineData(true, "")]
    public void NotFoundException_When_Meets_Condition(bool condition, string message)
    {
        if (condition)
        {
            Assert.Throws<StateNotFoundException>(() => StateNotFoundException.ThrowIf(condition, message));
            return;
        }

        StateNotFoundException.ThrowIf(condition, message);
        Assert.True(true);
    }

    [Fact]
    public void NotFoundException_Serialization()
    {
        var e = new StateNotFoundException(ExpectedMessage);

        using (Stream s = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(s, e);
            s.Position = 0; // Reset stream position
            e = (StateNotFoundException)formatter.Deserialize(s);
        }

        Assert.Equal(ExpectedMessage, e.Message);
    }
}
