using System;

namespace IMustafaZeynali.IResultPattern
{
    public struct Result<TData> : IResult
              where TData : class
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public TData? Data { get; set; }
        public ResultStatusCode StatusCode { get; set; }
        public string StatusCodeTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static Result<TData> Failure(string errorMessage)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Failure,
            };
        }


        public static Result<TData> Success(TData data)
        {
            return new Result<TData>()
            {
                Data = data,
                IsSuccess = true,
                StatusCode = ResultStatusCode.Success,
            };
        }

        public static Result<TData> Created(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Created,
            };
        }

        public static Result<TData> NoContent(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.NoContent,
            };
        }


        public static Result<TData> BadRequest(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.BadRequest,
            };
        }

        public static Result<TData> UnAuthorized(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.UnAuthorized,
            };
        }

        public static Result<TData> Forbidden(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Forbidden,
            };
        }

        public static Result<TData> NotFound(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.NotFound,
            };
        }

        public static Result<TData> Conflict(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Conflict,
            };
        }

        public static Result<TData> ValidationError(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.ValidationError,
            };
        }


        public static Result<TData> InternalServerError(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.InternalServerError,
            };
        }

        public static Result<TData> ServiceUnavailable(string? errorMessage = null)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.ServiceUnavailable,
            };
        }


        public static implicit operator Result<TData>(TData data)
        {
            return Success(data);
        }

    }
}