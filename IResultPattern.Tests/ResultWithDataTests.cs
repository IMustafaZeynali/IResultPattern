using IMustafaZeynali.IResultPattern;

namespace IResultPattern.Tests;

public class ResultWithDataTests
{
    private sealed class SampleDto
    {
        public string Name { get; init; } = string.Empty;
    }

    [Fact]
    public void Success_Should_Set_Data_And_Success_Status()
    {
        var data = new SampleDto { Name = "mustafa" };

        var result = Result<SampleDto>.Success(data);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Success, result.StatusCode);
        Assert.Equal("Success", result.StatusTitle);
        Assert.Same(data, result.Data);
        Assert.Null(result.Message);
    }

    [Fact]
    public void Implicit_From_Data_Should_Create_Success_Result()
    {
        var data = new SampleDto { Name = "implicit" };

        Result<SampleDto> result = data;

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Success, result.StatusCode);
        Assert.Same(data, result.Data);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("created")]
    public void Created_Should_Set_Created_Status(string? message)
    {
        var result = Result<SampleDto>.Created(message);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Created, result.StatusCode);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Data);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("no content")]
    public void NoContent_Should_Set_NoContent_Status(string? message)
    {
        var result = Result<SampleDto>.NoContent(message);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.NoContent, result.StatusCode);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Data);
    }

    [Theory]
    [InlineData(nameof(Result<SampleDto>.BadRequest), ResultStatus.BadRequest)]
    [InlineData(nameof(Result<SampleDto>.Unauthorized), ResultStatus.Unauthorized)]
    [InlineData(nameof(Result<SampleDto>.Forbidden), ResultStatus.Forbidden)]
    [InlineData(nameof(Result<SampleDto>.NotFound), ResultStatus.NotFound)]
    [InlineData(nameof(Result<SampleDto>.Conflict), ResultStatus.Conflict)]
    [InlineData(nameof(Result<SampleDto>.ValidationError), ResultStatus.ValidationError)]
    [InlineData(nameof(Result<SampleDto>.InternalServerError), ResultStatus.InternalServerError)]
    [InlineData(nameof(Result<SampleDto>.ServiceUnavailable), ResultStatus.ServiceUnavailable)]
    public void Failure_Factories_Should_Set_Expected_Status(string factoryName, ResultStatus expectedStatus)
    {
        const string message = "error message";

        Result<SampleDto> result = factoryName switch
        {
            nameof(Result<SampleDto>.BadRequest) => Result<SampleDto>.BadRequest(message),
            nameof(Result<SampleDto>.Unauthorized) => Result<SampleDto>.Unauthorized(message),
            nameof(Result<SampleDto>.Forbidden) => Result<SampleDto>.Forbidden(message),
            nameof(Result<SampleDto>.NotFound) => Result<SampleDto>.NotFound(message),
            nameof(Result<SampleDto>.Conflict) => Result<SampleDto>.Conflict(message),
            nameof(Result<SampleDto>.ValidationError) => Result<SampleDto>.ValidationError(message),
            nameof(Result<SampleDto>.InternalServerError) => Result<SampleDto>.InternalServerError(message),
            nameof(Result<SampleDto>.ServiceUnavailable) => Result<SampleDto>.ServiceUnavailable(message),
            _ => throw new InvalidOperationException(factoryName)
        };

        Assert.False(result.IsSuccess);
        Assert.Equal(expectedStatus, result.StatusCode);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Failure_With_Status_Should_Use_Provided_Status_And_Message()
    {
        var result = Result<SampleDto>.Failure(ResultStatus.Conflict, "exists");

        Assert.False(result.IsSuccess);
        Assert.Equal(ResultStatus.Conflict, result.StatusCode);
        Assert.Equal("exists", result.Message);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Obsolete_Failure_With_Message_Should_Use_InternalServerError()
#pragma warning disable CS0618
    {
        var result = Result<SampleDto>.Failure("boom");

        Assert.False(result.IsSuccess);
        Assert.Equal(ResultStatus.InternalServerError, result.StatusCode);
        Assert.Equal("boom", result.Message);
        Assert.Null(result.Data);
    }
#pragma warning restore CS0618

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
        Result<SampleDto> result = status;

        Assert.False(result.IsSuccess);
        Assert.Equal(status, result.StatusCode);
        Assert.Null(result.Data);
        Assert.Null(result.Message);
    }

    [Theory]
    [InlineData(ResultStatus.Success)]
    [InlineData(ResultStatus.Created)]
    [InlineData(ResultStatus.NoContent)]
    public void Implicit_From_Success_Status_Should_Throw(ResultStatus status)
    {
        Assert.Throws<InvalidResultOperationException>(() =>
        {
            Result<SampleDto> _ = status;
        });
    }
}
