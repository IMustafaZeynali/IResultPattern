namespace IMustafaZeynali.IResultPattern
{
    public struct Result<TData> : IResult
            where TData : class
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }

        public TData? Data { get; private set; }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>()
            {
                Data = data,
                IsSuccess = true,
            };
        }

        public static implicit operator Result<TData>(TData data)
        {
            return Success(data);
        }

        public static Result<TData> Failure(string errorMessage)
        {
            return new Result<TData>()
            {
                IsSuccess = false,
                Message = errorMessage,
            };
        }
    }


    public struct Result : IResult
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }

        public static Result Success()
        {
            return new Result()
            {
                IsSuccess = true,
            };
        }

        public static Result Failure(string errorMessage)
        {
            return new Result()
            {
                IsSuccess = false,
                Message = errorMessage,
            };
        }

    }
}
