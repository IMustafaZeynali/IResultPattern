using System;

namespace IMustafaZeynali.IResultPattern
{
    public struct Result<TData> : IResult
              where TData : class
    {
        public bool IsSuccess => ReulstPatternExtenssion.CalculateIsSuccess(this.StatusCode);
        public string? Message { get; set; }
        public TData? Data { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string StatusTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static Result<TData> Failure(string errorMessage)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }


        public static Result<TData> Success(TData data)
        {
            return new Result<TData>()
            {
                Data = data,
                StatusCode = ResultStatus.Success,
            };
        }

        public static Result<TData> Created(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Created,
            };
        }

        public static Result<TData> NoContent(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NoContent,
            };
        }


        public static Result<TData> BadRequest(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.BadRequest,
            };
        }

        public static Result<TData> UnAuthorized(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.UnAuthorized,
            };
        }

        public static Result<TData> Forbidden(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Forbidden,
            };
        }

        public static Result<TData> NotFound(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NotFound,
            };
        }

        public static Result<TData> Conflict(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Conflict,
            };
        }

        public static Result<TData> ValidationError(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ValidationError,
            };
        }


        public static Result<TData> InternalServerError(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }

        public static Result<TData> ServiceUnavailable(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ServiceUnavailable,
            };
        }


        public static implicit operator Result<TData>(TData data)
        {
            return Success(data);
        }

    }
}