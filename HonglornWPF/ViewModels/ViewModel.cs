using HonglornBL;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    abstract class ViewModel : NotifyPropertyChangedInformer
    {
        protected Honglorn Honglorn { get; }

        protected ViewModel()
        {
            Honglorn = HonglornApi.Instance;
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