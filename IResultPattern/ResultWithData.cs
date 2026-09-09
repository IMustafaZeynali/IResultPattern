using System;

namespace IMustafaZeynali.IResultPattern
{
    public readonly struct Result<TData> : IResult
        where TData : class
    {
        public bool IsSuccess =>
            ResultPatternExtension.CalculateIsSuccess(StatusCode);

        public string? Message { get; }

        public TData? Data { get; }

        public ResultStatus StatusCode { get; }

        private Result(
            ResultStatus statusCode,
            string? message = null,
            TData? data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        [Obsolete("Use specific status instead.")]
        public static Result<TData> Failure(string errorMessage)
        {
            return new Result<TData>(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static Result<TData> Failure(
            ResultStatus resultStatus,
            string? errorMessage = null)
        {
            return new Result<TData>(
                resultStatus,
                errorMessage);
        }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>(
                ResultStatus.Success,
                data: data);
        }

        public static Result<TData> Created(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.Created,
                errorMessage);
        }

        public static Result<TData> NoContent(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.NoContent,
                errorMessage);
        }

        public static Result<TData> BadRequest(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.BadRequest,
                errorMessage);
        }

        public static Result<TData> Unauthorized(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.Unauthorized,
                errorMessage);
        }

        public static Result<TData> Forbidden(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.Forbidden,
                errorMessage);
        }

        public static Result<TData> NotFound(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.NotFound,
                errorMessage);
        }

        public static Result<TData> Conflict(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.Conflict,
                errorMessage);
        }

        public static Result<TData> ValidationError(string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.ValidationError,
                errorMessage);
        }

        public static Result<TData> InternalServerError(
            string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static Result<TData> ServiceUnavailable(
            string? errorMessage = null)
        {
            return new Result<TData>(
                ResultStatus.ServiceUnavailable,
                errorMessage);
        }

        public static implicit operator Result<TData>(TData data)
        {
            return Success(data);
        }

        public static implicit operator Result<TData>(
            ResultStatus resultStatus)
        {
            if (ResultPatternExtension.CalculateIsSuccess(resultStatus))
                throw new InvalidResultOperationException();

            return Failure(resultStatus);
        }
    }
}
