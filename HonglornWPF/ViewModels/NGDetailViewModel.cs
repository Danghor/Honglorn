using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class NGDetailViewModel<T> : ContextViewModel
        where T: class
    {
        public T Entity { get; }

        // TODO: Swap Accept and Cancel for better readability
        protected NGDetailViewModel(HonglornDb context, Guid entityKey) : base(context)
        {
            Entity = context.Class.Find(entityKey);
        }
    }
}
