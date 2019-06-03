using System.Collections.Generic;

namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : ViewModel
    {
        ViewModel currentPageViewModel;

        public ViewModel CurrentPageViewModel
        {
            get => currentPageViewModel;
            set => OnPropertyChanged(out currentPageViewModel, value);
        }

        public IEnumerable<ViewModel> ViewModels { get; } = new ViewModel[] { new ClassListViewModel(), new CourseListViewModel() };
    }
}