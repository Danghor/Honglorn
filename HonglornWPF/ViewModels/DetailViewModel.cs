using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    abstract class DetailViewModel<TModel> : ViewModel
    {
        internal abstract void Clear();

        internal abstract void CopyValues(TModel model);
    }
}