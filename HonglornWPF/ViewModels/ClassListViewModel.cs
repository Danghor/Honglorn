using HonglornBL.MasterData.Class;
using HonglornBL.Models.Entities;
using System;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : NGListViewModel<ClassService, Class>
    {

        public ClassListViewModel(ClassService service) : base(service) { }

        protected override NGDetailViewModel<ClassService, Class> CreateDetailViewModel(ClassService service, Guid entityKey)
        {
            return new ClassDetailViewModel(service, entityKey);
        }

        public override string ToString() => "Classes";
    }
}