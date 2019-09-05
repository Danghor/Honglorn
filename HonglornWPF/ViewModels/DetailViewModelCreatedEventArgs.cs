using System;

namespace HonglornWPF.ViewModels
{
    class DetailViewModelCreatedEventArgs<T> : EventArgs
    {
        internal NGDetailViewModel<T> DetailViewModel { get; }

        public DetailViewModelCreatedEventArgs(NGDetailViewModel<T> detailViewModel)
        {
            DetailViewModel = detailViewModel;
        }
    }
}
