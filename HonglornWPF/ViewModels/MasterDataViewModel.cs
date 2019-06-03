namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : ViewModel
    {
        ViewModel currentDetailViewModel;

        public ViewModel CurrentDetailViewModel
        {
            get => currentDetailViewModel;
            set => OnPropertyChanged(out currentDetailViewModel, value);
        }
    }
}