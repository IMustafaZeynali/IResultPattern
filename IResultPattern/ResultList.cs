using System.Collections.Generic;

namespace IMustafaZeynali.IResultPattern
{
    public struct ResultList<TData> : IResult
          where TData : class
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public IEnumerable<TData>? Data { get; private set; }
        public int TotalCount { get; private set; }


        public static ResultList<TData> Success(IEnumerable<TData> data, int totalCount)
        {
            return new ResultList<TData>()
            {
                Data = data,
                IsSuccess = true,
                TotalCount = totalCount,
            };
        }

        public static ResultList<TData> Failure(string errorMessages)
        {
            return new ResultList<TData>()
            {
                IsSuccess = false,
                Message = errorMessages,
            };
        }

    }
}
