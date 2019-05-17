using System.Collections.Generic;

namespace HonglornBL
{
    public interface IGameManager<TResult>
    {
        ICollection<TResult> CalculateResults();
    }
}