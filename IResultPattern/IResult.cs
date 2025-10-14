namespace IMustafaZeynali.ResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
        //int StatusCode { get; }
    }
}
