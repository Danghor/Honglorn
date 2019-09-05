using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : NGDetailViewModel<Class>
    {
        public ClassDetailViewModel(Action cancelAction, Action acceptAction, Class entity)
            : base(cancelAction, acceptAction, entity) { }

        public override string ToString() => $"Class - {Entity.Name}";
    }
}