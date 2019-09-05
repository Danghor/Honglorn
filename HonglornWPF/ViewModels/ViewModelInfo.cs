using System;

namespace HonglornWPF.ViewModels
{
    public class ViewModelInfo
    {
        internal readonly Func<TabViewModel> CreateViewModel;
        private readonly string name;

        internal ViewModelInfo(Func<TabViewModel> createViewModel, string name)
        {
            CreateViewModel = createViewModel;
            this.name = name;
        }

        public override string ToString() => name;
    }
}
