using System;

namespace HonglornWPF.ViewModels
{
    interface IGameWrapper
    {
        string Name { get; }
        DateTime Date { get; }
        ViewModel CreateViewModel();
    }
}
