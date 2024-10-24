using System.Collections.Generic;

namespace IMustafa.IResultPattern
{
    public interface IResultPattern
    {
        bool IsSuccess { get; }
        IEnumerable<string>? ErrorMessages { get; }
    }
}
