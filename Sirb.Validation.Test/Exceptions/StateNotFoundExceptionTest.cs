using Sirb.Validation.Exceptions;
using System;
using Xunit;

namespace Sirb.Validation.Test.Exceptions;

public class StateNotFoundExceptionTest
{
    private const string ExpectedMessage = "State not found";

    [Fact(DisplayName = "StateNotFoundException constructor should create a non-null instance")]
    public void NotFoundException_Should_Be_Created()
    {
        var exception = new StateNotFoundException();
        Assert.NotNull(exception);
    }

    [Fact(DisplayName = "StateNotFoundException should preserve inner exception passed to constructor")]
    public void NotFoundException_Should_Have_Correct_Inner_Exception()
    {
        var expectedInnerException = new Exception();
        var exception = new StateNotFoundException(expectedInnerException);

        Assert.Equal(expectedInnerException, exception.InnerException);
    }

    [Fact(DisplayName = "StateNotFoundException should set the message passed to constructor")]
    public void NotFoundException_Should_Have_Correct_Message()
    {
        var exception = new StateNotFoundException(ExpectedMessage);

        Assert.Equal(ExpectedMessage, exception.Message);
    }

    [Theory(DisplayName = "StateNotFoundException should use default message for null or empty message")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void NotFoundException_NullOrEmptyMessage_UsesDefault(string message)
    {
        var exception = new StateNotFoundException(message);
        Assert.Equal(ExpectedMessage, exception.Message);
    }

    [Fact(DisplayName = "StateNotFoundException with null message and inner exception should use default message")]
    public void NotFoundException_NullMessageWithInnerException_UsesDefault()
    {
        var inner = new Exception();
        var exception = new StateNotFoundException(null, inner);
        Assert.Equal(ExpectedMessage, exception.Message);
        Assert.Equal(inner, exception.InnerException);
    }

    [Fact(DisplayName = "StateNotFoundException with empty message and inner exception should use default message")]
    public void NotFoundException_EmptyMessageWithInnerException_UsesDefault()
    {
        var inner = new Exception();
        var exception = new StateNotFoundException("", inner);
        Assert.Equal(ExpectedMessage, exception.Message);
        Assert.Equal(inner, exception.InnerException);
    }

    [Theory(DisplayName = "StateNotFoundException.ThrowIf should throw when condition is true")]
    [InlineData(true, "Exception message")]
    [InlineData(false, "Exception message")]
    [InlineData(true, "")]
    [InlineData(true, null)]
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

    [Fact(DisplayName = "StateNotFoundException.ThrowIf with inner exception should throw when condition is true")]
    public void NotFoundException_ThrowIf_WithInnerException_Throws()
    {
        var inner = new Exception("inner");
        Assert.Throws<StateNotFoundException>(() =>
            StateNotFoundException.ThrowIf(true, "test message", inner));
    }
}
