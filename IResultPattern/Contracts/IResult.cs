namespace IResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
        ResultStatusCode StatusCode { get; set; }
        string StatusCodeTitle { get; }
    }
}
