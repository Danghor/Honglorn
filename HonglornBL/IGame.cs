using System.Collections.Generic;

namespace HonglornBL
{
    public interface IGame<TResult>
    {
        ICollection<TResult> CalculateResults();
    }
}