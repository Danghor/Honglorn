using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    internal abstract class ContextViewModel : TabViewModel
    {
        protected HonglornDb Context { get; }

        protected ContextViewModel(HonglornDb context)
        {
            Context = context;
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
