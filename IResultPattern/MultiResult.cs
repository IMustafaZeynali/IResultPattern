using System.Collections.Generic;

namespace IMustafa.IResultPattern
{
    public struct MultiResult<TData> : IResultPattern
          where TData : class
    {
        public bool IsSuccess { get; private set; }
        public IEnumerable<string>? ErrorMessages { get; private set; }

        public IEnumerable<TData>? Data { get; private set; }
        public int TotalCount { get; private set; }


        public static MultiResult<TData> Success(IEnumerable<TData> data, int totalCount)
        {
            return new MultiResult<TData>()
            {
                Data = data,
                IsSuccess = true,
                TotalCount = totalCount,
            };
        }

        public static MultiResult<TData> Failure(IEnumerable<string> errorMessages)
        {
            return new MultiResult<TData>()
            {
                IsSuccess = false,
                ErrorMessages = errorMessages,
            };
        }

    }
}
