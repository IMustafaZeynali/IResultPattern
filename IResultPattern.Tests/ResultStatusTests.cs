using IMustafaZeynali.IResultPattern;

namespace IResultPattern.Tests;

public class ResultStatusTests
{
    [Theory]
    [InlineData(ResultStatus.Success, 200u)]
    [InlineData(ResultStatus.Created, 201u)]
    [InlineData(ResultStatus.NoContent, 204u)]
    [InlineData(ResultStatus.BadRequest, 400u)]
    [InlineData(ResultStatus.Unauthorized, 401u)]
    [InlineData(ResultStatus.Forbidden, 403u)]
    [InlineData(ResultStatus.NotFound, 404u)]
    [InlineData(ResultStatus.Conflict, 409u)]
    [InlineData(ResultStatus.ValidationError, 422u)]
    [InlineData(ResultStatus.InternalServerError, 500u)]
    [InlineData(ResultStatus.ServiceUnavailable, 503u)]
    public void Enum_Values_Should_Match_Http_Status_Codes(ResultStatus status, uint expectedCode)
    {
        Assert.Equal(expectedCode, (uint)status);
    }
}
