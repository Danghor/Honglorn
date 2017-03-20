using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HonglornWPF.ViewModels
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void ClearAndFill<T>(ObservableCollection<T> collection, IEnumerable<T> content)
        {
            collection.Clear();

            foreach (T item in content)
            {
                collection.Add(item);
            }
        }
    }
}
