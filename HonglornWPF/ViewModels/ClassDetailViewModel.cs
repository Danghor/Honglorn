using System;
using HonglornBL.MasterData.Class;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : DetailViewModel<ClassManager>, IClassModel
    {
        string name;

        public string Name
        {
            get => name;
            set => OnPropertyChanged(out name, value);
        }

        public Guid PKey { get; }

        public ClassDetailViewModel(Action cancelAction) : base(cancelAction) { }

        internal override void Clear()
        {
            Name = default;
        }

        internal override void CopyValues(ClassManager model)
        {
            Name = model.Name;
        }
    }
}