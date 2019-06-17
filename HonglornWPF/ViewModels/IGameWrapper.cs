using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    interface IGameWrapper
    {
        string Name { get; }
        DateTime Date { get; }
    }
}
