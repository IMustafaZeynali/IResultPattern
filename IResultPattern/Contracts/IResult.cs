namespace IMustafaZeynali.IResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
        ResultStatus StatusCode { get; set; }
        string StatusTitle { get; }
    }
}
