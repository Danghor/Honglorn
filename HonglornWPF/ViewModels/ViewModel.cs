using System;
using HonglornBL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class ViewModel : NotifyPropertyChangedInformer
    {
        internal event EventHandler OnCloseButtonPressed;

        public ICommand CloseCommand { get; }

        protected Honglorn Honglorn { get; }

        protected ViewModel()
        {
            Honglorn = HonglornApi.Instance;
            CloseCommand = new RelayCommand(() => OnCloseButtonPressed?.Invoke(this, EventArgs.Empty));
        }

        protected static void ClearAndFill<T>(ObservableCollection<T> collection, IEnumerable<T> content)
        {
            collection.Clear();

            foreach (T item in content)
            {
                collection.Add(item);
            }
        }
    }
}