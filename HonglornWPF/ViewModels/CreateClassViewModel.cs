using HonglornBL.Models.Entities;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    class CreateClassViewModel : ViewModel
    {
        public Class CurrentClass { get; }
        public ICommand AcceptCommand { get; }
        public ICommand AbortCommand { get; }

        public CreateClassViewModel(Action<CreateClassViewModel> acceptHandle, Action<CreateClassViewModel> abortHandle, Class @class = null)
        {
            AcceptCommand = new RelayCommand(() => acceptHandle(this));
            AbortCommand = new RelayCommand(() => abortHandle(this));

            CurrentClass = @class ?? new Class();
        }
    }
}