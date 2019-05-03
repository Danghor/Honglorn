using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    public interface IGame
    {
        ICollection<IStudentResult> CalculateResults();
    }
}