using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : ViewModel
    {
        public ObservableCollection<ViewModel> Tabs { get; } = new ObservableCollection<ViewModel>();

        public IEnumerable<ViewModelInfo> ViewModelInfos { get; }

        public MasterDataViewModel()
        {
            ViewModelInfos = new[]
            {
                new ViewModelInfo(() => CreateAndSubscribe(() => new ClassListViewModel()), "Classes"),
                new ViewModelInfo(() => CreateAndSubscribe(() => new CourseListViewModel()), "Courses"),
                new ViewModelInfo(() => CreateAndSubscribe(() => new StudentListViewModel()), "Students")
            };
        }

        private ViewModel CreateAndSubscribe(Func<ViewModel> createViewModel)
        {
            var viewModel = createViewModel();
            viewModel.OnCloseButtonPressed += ViewModel_OnCloseButtonPressed;
            return viewModel;
        }

        private void ViewModel_OnCloseButtonPressed(object sender, System.EventArgs e)
        {
            Tabs.Remove((ViewModel)sender);
        }
    }
}