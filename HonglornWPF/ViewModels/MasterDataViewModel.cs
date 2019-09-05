using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : TabViewModel
    {
        public ObservableCollection<TabViewModel> Tabs { get; } = new ObservableCollection<TabViewModel>();

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

        private TabViewModel CreateAndSubscribe<T>(Func<NGListViewModel<T>> createViewModel) where T : class, new()
        {
            var viewModel = createViewModel();
            viewModel.OnCloseButtonPressed += ViewModel_OnCloseButtonPressed;
            viewModel.OnDetailViewModelCreated += ViewModel_OnDetailViewModelCreated;
            return viewModel;
        }

        private void ViewModel_OnDetailViewModelCreated<T>(object sender, DetailViewModelCreatedEventArgs<T> e)
        {
            e.DetailViewModel.OnCloseButtonPressed += ViewModel_OnCloseButtonPressed;
            Tabs.Add(e.DetailViewModel);
        }

        private void ViewModel_OnCloseButtonPressed(object sender, EventArgs e)
        {
            Tabs.Remove((TabViewModel)sender);
        }
    }
}