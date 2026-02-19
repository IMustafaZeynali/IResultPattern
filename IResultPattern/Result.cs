using System;

namespace IMustafaZeynali.IResultPattern
{
    public struct Result : IResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string StatusTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static Result Failure(string errorMessage)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.Failure,
            };
        }


        public static Result Success()
        {
            return new Result()
            {
                IsSuccess = true,
                StatusCode = ResultStatus.Success,
            };
        }

        public static Result Created(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.Created,
            };
        }

        public static Result NoContent(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.NoContent,
            };
        }


        public static Result BadRequest(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.BadRequest,
            };
        }

        public static Result UnAuthorized(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.UnAuthorized,
            };
        }

        public static Result Forbidden(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.Forbidden,
            };
        }

        public static Result NotFound(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.NotFound,
            };
        }

        public static Result Conflict(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.Conflict,
            };
        }

        public static Result ValidationError(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.ValidationError,
            };
        }


        public static Result InternalServerError(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }

        public static Result ServiceUnavailable(string? errorMessage = null)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatus.ServiceUnavailable,
            };
        }

    }
}
