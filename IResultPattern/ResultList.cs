using System.Collections.Generic;

namespace IMustafaZeynali.IResultPattern
{

    public struct ResultList<TData> : IResult, IPageInfo
          where TData : class
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public IEnumerable<TData>? Data { get; private set; }

        public int TotalItemCount { get; private set; }
        public int PageCount { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public static ResultList<TData> Success(
            IEnumerable<TData> data,
            int totalItemCount)
        {
            return new ResultList<TData>()
            {
                Data = data,
                IsSuccess = true,
                TotalItemCount = totalItemCount,
                PageCount = 1,
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
