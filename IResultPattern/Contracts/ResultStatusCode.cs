using System;

namespace IResultPattern
{
    public enum ResultStatusCode : uint
    {
        [Obsolete("Use specific status instead.")]
        Failure = 0,

        Success = 200,
        Created = 201,
        NoContent = 204,

        BadRequest = 400,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        ValidationError = 422,

        InternalServerError = 500,
        ServiceUnavailable = 503
    }
}
