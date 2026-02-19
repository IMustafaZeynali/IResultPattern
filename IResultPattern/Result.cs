using System;

namespace IMustafaZeynali.IResultPattern
{
    public struct Result : IResult
    {
        public bool IsSuccess => ReulstPatternExtenssion.CalculateIsSuccess(this.StatusCode);
        public string? Message { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string StatusTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static Result Failure(string errorMessage)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }


        public static Result Success()
        {
            return new Result()
            {
                StatusCode = ResultStatus.Success,
            };
        }

        public static Result Created(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Created,
            };
        }

        public static Result NoContent(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NoContent,
            };
        }


        public static Result BadRequest(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.BadRequest,
            };
        }

        public static Result Unauthorized(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Unauthorized,
            };
        }

        public static Result Forbidden(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Forbidden,
            };
        }

        public static Result NotFound(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NotFound,
            };
        }

        public static Result Conflict(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Conflict,
            };
        }

        public static Result ValidationError(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ValidationError,
            };
        }


        public static Result InternalServerError(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }

        public static Result ServiceUnavailable(string? errorMessage = null)
        {
            return new Result()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ServiceUnavailable,
            };
        }

    }
}
