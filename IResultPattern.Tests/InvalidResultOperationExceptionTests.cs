namespace IResultPattern.Tests;

public class InvalidResultOperationExceptionTests
{
    [Fact]
    public void Default_Constructor_Should_Use_Expected_Message()
    {
        var exception = new InvalidResultOperationException();

        Assert.Equal(
            "The provided status code is a success status code. Use Success instead of Failure.",
            exception.Message);
    }
}
