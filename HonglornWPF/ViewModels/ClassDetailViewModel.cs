using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using HonglornBL.MasterData.Class;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : NGDetailViewModel<ClassService, Class>
    {
        public ClassDetailViewModel(ClassService service, Guid entityKey) : base(service, entityKey) { }

        public override string ToString() => $"Class - {Entity.Name}";
    }
}