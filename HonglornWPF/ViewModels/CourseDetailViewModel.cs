using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL.MasterData.Course;

namespace HonglornWPF.ViewModels
{
    class CourseDetailViewModel : DetailViewModel<CourseManager>, ICourseModel
    {
        string name;

        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name, value);
        }

        public IDictionary<Guid, string> ValidClassValues { get; }

        KeyValuePair<Guid, string>? currentClass;

        public KeyValuePair<Guid, string>? CurrentClass
        {
            get => currentClass;
            set => OnPropertyChanged(out currentClass, value);
        }

        public Guid ClassPKey => CurrentClass?.Key ?? default;

        public CourseDetailViewModel(Action cancelAction) : base(cancelAction)
        {
            ValidClassValues = Honglorn.ClassService().GetManagers().ToDictionary(m => m.PKey, m => m.Name);
        }

        internal override void Clear()
        {
            Name = default;
            CurrentClass = default;
        }

        internal override void CopyValues(CourseManager model)
        {
            Name = model.Name;
            CurrentClass = ValidClassValues.SingleOrDefault(i => i.Key == model.ClassPKey);
        }
    }
}