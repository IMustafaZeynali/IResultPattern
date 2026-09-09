using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMustafaZeynali.IResultPattern
{
    public readonly struct ResultList<TData> : IResult, IPageInfo
        where TData : class
    {
        public bool IsSuccess =>
            ResultPatternExtension.CalculateIsSuccess(StatusCode);

        public string? Message { get; }

        public IEnumerable<TData>? Data { get; }

        public int TotalItemCount { get; }

        public int PageCount { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public ResultStatus StatusCode { get; }

        private ResultList(
            ResultStatus statusCode,
            string? message = null,
            IEnumerable<TData>? data = null,
            int totalItemCount = 0,
            int pageCount = 0,
            int pageNumber = 0,
            int pageSize = 0)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            TotalItemCount = totalItemCount;
            PageCount = pageCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        [Obsolete("Use specific status instead.")]
        public static ResultList<TData> Failure(string errorMessage)
        {
            return new ResultList<TData>(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static ResultList<TData> Failure(
            ResultStatus resultStatus,
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                resultStatus,
                errorMessage);
        }

        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            int totalItemCount)
        {
            return new ResultList<TData>(
                ResultStatus.Success,
                data: data,
                totalItemCount: totalItemCount,
                pageCount: GetPageCount(
                    totalItemCount: totalItemCount,
                    data: data),
                pageNumber: 1,
                pageSize: data.Count());
        }

        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            IPageInfo pageInfo)
        {
            return new ResultList<TData>(
                ResultStatus.Success,
                data: data,
                totalItemCount: pageInfo.TotalItemCount,
                pageCount: pageInfo.PageCount,
                pageNumber: pageInfo.PageNumber,
                pageSize: pageInfo.PageSize);
        }

        public static ResultList<TData> Created(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.Created,
                errorMessage);
        }

        public static ResultList<TData> NoContent(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.NoContent,
                errorMessage);
        }

        public static ResultList<TData> BadRequest(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.BadRequest,
                errorMessage);
        }

        public static ResultList<TData> Unauthorized(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.Unauthorized,
                errorMessage);
        }

        public static ResultList<TData> Forbidden(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.Forbidden,
                errorMessage);
        }

        public static ResultList<TData> NotFound(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.NotFound,
                errorMessage);
        }

        public static ResultList<TData> Conflict(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.Conflict,
                errorMessage);
        }

        public static ResultList<TData> ValidationError(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.ValidationError,
                errorMessage);
        }

        public static ResultList<TData> InternalServerError(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.InternalServerError,
                errorMessage);
        }

        public static ResultList<TData> ServiceUnavailable(
            string? errorMessage = null)
        {
            return new ResultList<TData>(
                ResultStatus.ServiceUnavailable,
                errorMessage);
        }

        public static implicit operator ResultList<TData>(
            ResultStatus resultStatus)
        {
            if (ResultPatternExtension.CalculateIsSuccess(resultStatus))
                throw new InvalidResultOperationException();

            return Failure(resultStatus);
        }

        private static int GetPageCount(
            int totalItemCount,
            IEnumerable<TData> data)
        {
            if (totalItemCount is 0 || data?.Count() is 0)
                return 0;

            var res = (int)(
                Math.Round(
                    ((decimal)(totalItemCount / data.Count())),
                    0,
                    MidpointRounding.AwayFromZero));

            return res;
        }
    }
}
