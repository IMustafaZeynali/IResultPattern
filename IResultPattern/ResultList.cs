using System;
using System.Collections.Generic;
using System.Linq;

namespace IMustafaZeynali.IResultPattern
{

    public struct ResultList<TData> : IResult, IPageInfo
          where TData : class
    {
        public bool IsSuccess => StatusCode == ResultStatus.Success;
        public string? Message { get; set; }
        public IEnumerable<TData>? Data { get; set; }

        public int TotalItemCount { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string StatusTitle => this.StatusCode.ToString();


        [Obsolete("Use specific status instead.")]
        public static ResultList<TData> Failure(string errorMessage)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }


        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            int totalItemCount)
        {
            return new ResultList<TData>()
            {
                Data = data,
                TotalItemCount = totalItemCount,
                PageCount = ((int)(Math.Round(((decimal)(totalItemCount / data.Count())), 0, MidpointRounding.AwayFromZero))),
                PageNumber = 1,
                PageSize = totalItemCount,
                StatusCode = ResultStatus.Success,
            };
        }

        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            IPageInfo pageInfo)
        {
            return new ResultList<TData>()
            {
                Data = data,
                TotalItemCount = pageInfo.TotalItemCount,
                PageCount = pageInfo.PageCount,
                PageNumber = pageInfo.PageNumber,
                PageSize = pageInfo.PageSize,
                StatusCode = ResultStatus.Success,
            };
        }

        public static ResultList<TData> Created(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Created,
            };
        }

        public static ResultList<TData> NoContent(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NoContent,
            };
        }


        public static ResultList<TData> BadRequest(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.BadRequest,
            };
        }

        public static ResultList<TData> UnAuthorized(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.UnAuthorized,
            };
        }

        public static ResultList<TData> Forbidden(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Forbidden,
            };
        }

        public static ResultList<TData> NotFound(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.NotFound,
            };
        }

        public static ResultList<TData> Conflict(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.Conflict,
            };
        }

        public static ResultList<TData> ValidationError(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ValidationError,
            };
        }


        public static ResultList<TData> InternalServerError(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.InternalServerError,
            };
        }

        public static ResultList<TData> ServiceUnavailable(string? errorMessage = null)
        {
            return new ResultList<TData>()
            {
                Message = errorMessage,
                StatusCode = ResultStatus.ServiceUnavailable,
            };
        }

    }
}
