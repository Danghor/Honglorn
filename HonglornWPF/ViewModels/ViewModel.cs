using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using HonglornBL;

namespace HonglornWPF.ViewModels
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Honglorn Honglorn { get; }

        protected ViewModel()
        {
            Honglorn = new Honglorn(ConfigurationManager.ConnectionStrings["HonglornDb"]);
        }

        protected void OnPropertyChanged<T>(out T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected static void ClearAndFill<T>(ObservableCollection<T> collection, IEnumerable<T> content)
        {
            collection.Clear();

            foreach (var item in content)
            {
                collection.Add(item);
            }
        }
    }
}
