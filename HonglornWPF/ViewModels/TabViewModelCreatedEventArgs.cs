using System;

namespace HonglornWPF.ViewModels
{
    class TabViewModelCreatedEventArgs : EventArgs
    {
        internal TabViewModel TabViewModel { get; }

        public TabViewModelCreatedEventArgs(TabViewModel tabViewModel)
        {
            TabViewModel = tabViewModel;
        }
    }
}
