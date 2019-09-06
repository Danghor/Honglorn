using HonglornBL.MasterData.Class;
using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : NGDetailViewModel<ClassService, Class>
    {
        public ClassDetailViewModel(ClassService service, Guid entityKey) : base(service, entityKey) { }
    }
}