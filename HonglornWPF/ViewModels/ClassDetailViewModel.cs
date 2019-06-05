using HonglornBL.Interfaces;
using System;

namespace HonglornWPF.ViewModels
{
    class ClassDetailViewModel : DetailViewModel<IClassModel>, IClassModel
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

        internal override void CopyValues(IClassModel model)
        {
            Name = model.Name;
        }
    }
}