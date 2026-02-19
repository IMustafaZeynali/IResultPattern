namespace IMustafaZeynali.IResultPattern
{
    public interface IPageInfo
    {
        int TotalItemCount { get; }
        int PageCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
    }
}
