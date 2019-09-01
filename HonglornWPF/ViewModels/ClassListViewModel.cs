using System;
using HonglornBL.MasterData;
using HonglornBL.MasterData.Class;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class ClassListViewModel : NGListViewModel<Class>
    {
        protected override NGService<Class> Service { get; }

        public ClassListViewModel()
        {
            Service = Honglorn.ClassService();
        }

        protected override NGDetailViewModel<Class> CreateDetailViewModel(Action cancelAction, Action acceptAction, Class entity)
        {
            return new ClassDetailViewModel(cancelAction, acceptAction, entity);
        }

        public override string ToString() => "Classes";
    }
}