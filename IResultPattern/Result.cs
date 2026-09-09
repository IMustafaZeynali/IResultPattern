using System;

namespace IMustafaZeynali.IResultPattern
{
    public readonly struct Result : IResult
    {
        public bool IsSuccess =>
            ResultPatternExtension.CalculateIsSuccess(StatusCode);

        public string? Message { get; }

        public ResultStatus StatusCode { get; }

        private Result(
            ResultStatus statusCode,
            string? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }

        [Obsolete("Use specific status instead.")]
        public static Result Failure(string errorMessage)
        {
            return new Result(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static Result Failure(
            ResultStatus resultStatus,
            string? errorMessage = null)
        {
            return new Result(
                resultStatus,
                errorMessage);
        }

        public static Result Success()
        {
            return new Result(ResultStatus.Success);
        }

        public static Result Created(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.Created,
                errorMessage);
        }

        public static Result NoContent(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.NoContent,
                errorMessage);
        }

        public static Result BadRequest(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.BadRequest,
                errorMessage);
        }

        public static Result Unauthorized(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.Unauthorized,
                errorMessage);
        }

        public static Result Forbidden(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.Forbidden,
                errorMessage);
        }

        public static Result NotFound(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.NotFound,
                errorMessage);
        }

        public static Result Conflict(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.Conflict,
                errorMessage);
        }

        public static Result ValidationError(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.ValidationError,
                errorMessage);
        }

        public static Result InternalServerError(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static Result ServiceUnavailable(string? errorMessage = null)
        {
            return new Result(
                ResultStatus.ServiceUnavailable,
                errorMessage);
        }

        public static implicit operator Result(ResultStatus resultStatus)
        {
            if (ResultPatternExtension.CalculateIsSuccess(resultStatus))
            {
                switch (resultStatus)
                {
                    case ResultStatus.Success:
                        return Success();

                    case ResultStatus.Created:
                        return Created();

                    case ResultStatus.NoContent:
                        return NoContent();
                }
            }

            return Failure(resultStatus);
        }
    }
}
