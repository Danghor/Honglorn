using HonglornBL;
using System;

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

        Guid classPKey;

        public Guid ClassPKey
        {
            get => classPKey;
            set => OnPropertyChanged(out classPKey, value);
        }

        public CourseDetailViewModel(Action cancelAction) : base(cancelAction) { }

        internal override void Clear()
        {
            Name = string.Empty;
            ClassPKey = Guid.Empty;
        }

        internal override void CopyValues(ICourseModel model)
        {
            Name = model.Name;
            ClassPKey = model.ClassPKey;
        }
    }
}
