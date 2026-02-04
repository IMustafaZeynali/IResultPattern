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
            };
        }

        public static ResultList<TData> Failure(string errorMessage)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
            };
        }

    }
}
