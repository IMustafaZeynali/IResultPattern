using IMustafaZeynali.IResultPattern;

namespace IResultPattern.Tests;

public class ResultListTests
{
    private sealed class SampleDto
    {
        public int Id { get; init; }
    }

    private sealed class PageInfoStub : IPageInfo
    {
        public int TotalItemCount { get; init; }
        public int PageCount { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }

    [Fact]
    public void Success_With_TotalItemCount_Should_Set_Paging_Defaults()
    {
        var data = new[]
        {
            new SampleDto { Id = 1 },
            new SampleDto { Id = 2 }
        };

        var result = ResultList<SampleDto>.Success(data, totalItemCount: 10);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Success, result.StatusCode);
        Assert.Same(data, result.Data);
        Assert.Equal(10, result.TotalItemCount);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(2, result.PageSize);
        Assert.Equal(5, result.PageCount);
        Assert.Null(result.Message);
    }

    [Fact]
    public void Success_With_Empty_Data_Should_Set_PageCount_To_Zero()
    {
        var data = Array.Empty<SampleDto>();

        var result = ResultList<SampleDto>.Success(data, totalItemCount: 0);

        Assert.True(result.IsSuccess);
        Assert.Equal(0, result.TotalItemCount);
        Assert.Equal(0, result.PageCount);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(0, result.PageSize);
    }

    [Fact]
    public void Success_With_PageInfo_Should_Copy_Paging_Values()
    {
        var data = new[] { new SampleDto { Id = 1 } };
        var pageInfo = new PageInfoStub
        {
            TotalItemCount = 25,
            PageCount = 5,
            PageNumber = 2,
            PageSize = 5
        };

        var result = ResultList<SampleDto>.Success(data, pageInfo);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.Success, result.StatusCode);
        Assert.Same(data, result.Data);
        Assert.Equal(25, result.TotalItemCount);
        Assert.Equal(5, result.PageCount);
        Assert.Equal(2, result.PageNumber);
        Assert.Equal(5, result.PageSize);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("created")]
    public void Created_Should_Set_Created_Status(string? message)
    {
        var result = ResultList<SampleDto>.Created(message);

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
        var result = ResultList<SampleDto>.NoContent(message);

        Assert.True(result.IsSuccess);
        Assert.Equal(ResultStatus.NoContent, result.StatusCode);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Data);
    }

    [Theory]
    [InlineData(nameof(ResultList<SampleDto>.BadRequest), ResultStatus.BadRequest)]
    [InlineData(nameof(ResultList<SampleDto>.Unauthorized), ResultStatus.Unauthorized)]
    [InlineData(nameof(ResultList<SampleDto>.Forbidden), ResultStatus.Forbidden)]
    [InlineData(nameof(ResultList<SampleDto>.NotFound), ResultStatus.NotFound)]
    [InlineData(nameof(ResultList<SampleDto>.Conflict), ResultStatus.Conflict)]
    [InlineData(nameof(ResultList<SampleDto>.ValidationError), ResultStatus.ValidationError)]
    [InlineData(nameof(ResultList<SampleDto>.InternalServerError), ResultStatus.InternalServerError)]
    [InlineData(nameof(ResultList<SampleDto>.ServiceUnavailable), ResultStatus.ServiceUnavailable)]
    public void Failure_Factories_Should_Set_Expected_Status(string factoryName, ResultStatus expectedStatus)
    {
        const string message = "error message";

        ResultList<SampleDto> result = factoryName switch
        {
            nameof(ResultList<SampleDto>.BadRequest) => ResultList<SampleDto>.BadRequest(message),
            nameof(ResultList<SampleDto>.Unauthorized) => ResultList<SampleDto>.Unauthorized(message),
            nameof(ResultList<SampleDto>.Forbidden) => ResultList<SampleDto>.Forbidden(message),
            nameof(ResultList<SampleDto>.NotFound) => ResultList<SampleDto>.NotFound(message),
            nameof(ResultList<SampleDto>.Conflict) => ResultList<SampleDto>.Conflict(message),
            nameof(ResultList<SampleDto>.ValidationError) => ResultList<SampleDto>.ValidationError(message),
            nameof(ResultList<SampleDto>.InternalServerError) => ResultList<SampleDto>.InternalServerError(message),
            nameof(ResultList<SampleDto>.ServiceUnavailable) => ResultList<SampleDto>.ServiceUnavailable(message),
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
        var result = ResultList<SampleDto>.Failure(ResultStatus.Forbidden, "denied");

        Assert.False(result.IsSuccess);
        Assert.Equal(ResultStatus.Forbidden, result.StatusCode);
        Assert.Equal("denied", result.Message);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Obsolete_Failure_With_Message_Should_Use_InternalServerError()
#pragma warning disable CS0618
    {
        var result = ResultList<SampleDto>.Failure("boom");

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
        ResultList<SampleDto> result = status;

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
            ResultList<SampleDto> _ = status;
        });
    }
}
