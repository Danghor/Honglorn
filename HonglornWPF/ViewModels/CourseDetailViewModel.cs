using HonglornBL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornWPF.ViewModels
{
    class CourseDetailViewModel : DetailViewModel<ICourseModel>, ICourseModel
    {
        string name;

        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name, value);
        }

        public IEnumerable<Tuple<Guid, string>> ValidClassValues { get; }

        Tuple<Guid, string> currentClass;

        public Tuple<Guid, string> CurrentClass
        {
            get => currentClass;
            set => OnPropertyChanged(out currentClass, value);
        }

        Guid classPKey;

        public Guid ClassPKey
        {
            get => CurrentClass.Item1;
        }

        public CourseDetailViewModel(Action cancelAction) : base(cancelAction)
        {
            ValidClassValues = Honglorn.ClassService().GetManagers().Select(m => new Tuple<Guid, string>(m.PKey, m.Name));
        }

        internal override void Clear()
        {
            Name = string.Empty;
            //ClassPKey = Guid.Empty;
        }

        internal override void CopyValues(ICourseModel model)
        {
            Name = model.Name;
            //ClassPKey = model.ClassPKey;
        }
    }
}