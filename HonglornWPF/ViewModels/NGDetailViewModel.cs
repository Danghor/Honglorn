using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class NGDetailViewModel<T> : ViewModel
    {
        public T Entity { get; }

        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }

        // TODO: Swap Accept and Cancel for better readability
        protected NGDetailViewModel(Action cancelAction, Action acceptAction, T entity)
        {
            CancelCommand = new RelayCommand(cancelAction);
            AcceptCommand = new RelayCommand(acceptAction);

            Entity = entity;
        }
    }
}
