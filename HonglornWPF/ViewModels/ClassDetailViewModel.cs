using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : NGDetailViewModel<Class>
    {
        public ClassDetailViewModel(HonglornDb context) : base(context) { }

        public override string ToString() => $"Class - {Entity.Name}";
    }
}