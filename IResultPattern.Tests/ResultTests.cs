using IMustafaZeynali.IResultPattern;

namespace IResultPattern.Tests;

public class ResultTests
{
    [Fact]
    public void Success_Should_Set_Success_Status_And_IsSuccess()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Success, result.StatusCode);
        Assert.Equal("Success", result.StatusTitle);
        Assert.Null(result.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("created")]
    public void Created_Should_Set_Created_Status(string? message)
    {
        var result = Result.Created(message);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Created, result.StatusCode);
        Assert.Equal("Created", result.StatusTitle);
        Assert.Equal(message, result.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("no content")]
    public void NoContent_Should_Set_NoContent_Status(string? message)
    {
        var result = Result.NoContent(message);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.NoContent, result.StatusCode);
        Assert.Equal(message, result.Message);
    }

    [Theory]
    [InlineData(nameof(Result.BadRequest), ResultStatus.BadRequest)]
    [InlineData(nameof(Result.Unauthorized), ResultStatus.Unauthorized)]
    [InlineData(nameof(Result.Forbidden), ResultStatus.Forbidden)]
    [InlineData(nameof(Result.NotFound), ResultStatus.NotFound)]
    [InlineData(nameof(Result.Conflict), ResultStatus.Conflict)]
    [InlineData(nameof(Result.ValidationError), ResultStatus.ValidationError)]
    [InlineData(nameof(Result.InternalServerError), ResultStatus.InternalServerError)]
    [InlineData(nameof(Result.ServiceUnavailable), ResultStatus.ServiceUnavailable)]
    public void Failure_Factories_Should_Set_Expected_Status(string factoryName, ResultStatus expectedStatus)
    {
        const string message = "error message";

        Result result = factoryName switch
        {
            nameof(Result.BadRequest) => Result.BadRequest(message),
            nameof(Result.Unauthorized) => Result.Unauthorized(message),
            nameof(Result.Forbidden) => Result.Forbidden(message),
            nameof(Result.NotFound) => Result.NotFound(message),
            nameof(Result.Conflict) => Result.Conflict(message),
            nameof(Result.ValidationError) => Result.ValidationError(message),
            nameof(Result.InternalServerError) => Result.InternalServerError(message),
            nameof(Result.ServiceUnavailable) => Result.ServiceUnavailable(message),
            _ => throw new InvalidOperationException(factoryName)
        };

        Assert.False(result.IsSuccess);
        Assert.Equal(expectedStatus, result.StatusCode);
        Assert.Equal(expectedStatus.ToString(), result.StatusTitle);
        Assert.Equal(message, result.Message);
    }

    [Fact]
    public void Failure_With_Status_Should_Use_Provided_Status_And_Message()
    {
        var result = Result.Failure(ResultStatus.NotFound, "missing");

        Assert.False(result.IsSuccess);
        Assert.Equal(ResultStatus.NotFound, result.StatusCode);
        Assert.Equal("missing", result.Message);
    }

    [Fact]
    public void Obsolete_Failure_With_Message_Should_Use_InternalServerError()
#pragma warning disable CS0618
    {
        var result = Result.Failure("boom");

        Assert.False(result.IsSuccess);
        Assert.Equal(ResultStatus.InternalServerError, result.StatusCode);
        Assert.Equal("boom", result.Message);
    }
#pragma warning restore CS0618

    [Theory]
    [InlineData(ResultStatus.Success)]
    [InlineData(ResultStatus.Created)]
    [InlineData(ResultStatus.NoContent)]
    public void Implicit_From_Success_Status_Should_Create_Matching_Result(ResultStatus status)
    {
        Result result = status;

        Assert.True(result.IsSuccess);
        Assert.Equal(status, result.StatusCode);
        Assert.Null(result.Message);
    }

    [Theory]
    [InlineData(ResultStatus.BadRequest)]
    [InlineData(ResultStatus.Unauthorized)]
    [InlineData(ResultStatus.Forbidden)]
    [InlineData(ResultStatus.NotFound)]
    [InlineData(ResultStatus.Conflict)]
    [InlineData(ResultStatus.ValidationError)]
    [InlineData(ResultStatus.InternalServerError)]
    [InlineData(ResultStatus.ServiceUnavailable)]
    public void Implicit_From_Failure_Status_Should_Create_Failure_Result(ResultStatus status)
    {
        Result result = status;

        Assert.False(result.IsSuccess);
        Assert.Equal(status, result.StatusCode);
        Assert.Null(result.Message);
    }
}
