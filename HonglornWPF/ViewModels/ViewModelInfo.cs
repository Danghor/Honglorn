using System;

namespace HonglornWPF.ViewModels
{
    public class ViewModelInfo
    {
        internal readonly Func<ViewModel> CreateViewModel;
        private readonly string name;

        internal ViewModelInfo(Func<ViewModel> createViewModel, string name)
        {
            CreateViewModel = createViewModel;
            this.name = name;
        }

        public override string ToString() => name;
    }
}
