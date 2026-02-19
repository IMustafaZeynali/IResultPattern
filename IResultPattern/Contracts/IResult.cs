namespace IResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
    }
}
