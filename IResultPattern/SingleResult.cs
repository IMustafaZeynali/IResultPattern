using System.Collections.Generic;
using System.Linq;

namespace IMustafa.IResultPattern
{
    public struct SingleResult<TData> : IResultPattern
            where TData : class
    {
        public bool IsSuccess { get; private set; }
        public IEnumerable<string>? ErrorMessages { get; private set; }

        public TData? Data { get; private set; }

        public static SingleResult<TData> Success(TData data)
        {
            return new SingleResult<TData>()
            {
                Data = data,
                IsSuccess = true,
            };
        }

        public static implicit operator SingleResult<TData>(TData data)
        {
            return Success(data);
        }

        public static SingleResult<TData> Failure(string errorMessage)
        {
            return new SingleResult<TData>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { errorMessage }.AsEnumerable(),
            };
        }

        public static SingleResult<TData> Failure(IEnumerable<string> errorMessages)
        {
            return new SingleResult<TData>()
            {
                IsSuccess = false,
                ErrorMessages = errorMessages,
            };
        }
    }


    public struct SingleResult : IResultPattern
    {
        public bool IsSuccess { get; private set; }
        public IEnumerable<string>? ErrorMessages { get; private set; }

        public static SingleResult Success()
        {
            return new SingleResult()
            {
                IsSuccess = true,
            };
        }

        public static SingleResult Failure(IEnumerable<string> errorMessages)
        {
            return new SingleResult()
            {
                IsSuccess = false,
                ErrorMessages = errorMessages,
            };
        }

    }
}
