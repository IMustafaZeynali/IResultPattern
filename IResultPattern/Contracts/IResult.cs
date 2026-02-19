namespace IResultPattern.Contracts
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
    }
}
