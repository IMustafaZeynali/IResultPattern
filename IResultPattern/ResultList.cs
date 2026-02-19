using IResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMustafaZeynali.IResultPattern
{

    public struct ResultList<TData> : IResult, IPageInfo
          where TData : class
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public IEnumerable<TData>? Data { get; set; }

        public int TotalItemCount { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ResultStatusCode StatusCode { get; set; }
        public string StatusCodeTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static ResultList<TData> Failure(string errorMessage)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Failure,
            };
        }


        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            int totalItemCount)
        {
            return new ResultList<TData>()
            {
                Data = data,
                IsSuccess = true,
                TotalItemCount = totalItemCount,
                PageCount = ((int)(Math.Round(((decimal)(totalItemCount / data.Count())), 0, MidpointRounding.AwayFromZero))),
                PageNumber = 1,
                PageSize = totalItemCount,
                StatusCode = ResultStatusCode.Success,
            };
        }

        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            IPageInfo pageInfo)
        {
            return new ResultList<TData>()
            {
                Data = data,
                IsSuccess = true,
                TotalItemCount = pageInfo.TotalItemCount,
                PageCount = pageInfo.PageCount,
                PageNumber = pageInfo.PageNumber,
                PageSize = pageInfo.PageSize,
                StatusCode = ResultStatusCode.Success,
            };
        }

        public static ResultList<TData> Created(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Created,
            };
        }

        public static ResultList<TData> NoContent(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.NoContent,
            };
        }


        public static ResultList<TData> BadRequest(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.BadRequest,
            };
        }

        public static ResultList<TData> UnAuthorized(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.UnAuthorized,
            };
        }

        public static ResultList<TData> Forbidden(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Forbidden,
            };
        }

        public static ResultList<TData> NotFound(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.NotFound,
            };
        }

        public static ResultList<TData> Conflict(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.Conflict,
            };
        }

        public static ResultList<TData> ValidationError(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.ValidationError,
            };
        }


        public static ResultList<TData> InternalServerError(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.InternalServerError,
            };
        }

        public static ResultList<TData> ServiceUnavailable(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
                StatusCode = ResultStatusCode.ServiceUnavailable,
            };
        }

    }
}
