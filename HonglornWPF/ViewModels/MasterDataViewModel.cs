using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Services;
using HonglornBL;
using HonglornBL.MasterData;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    class MasterDataViewModel : NotifyPropertyChangedInformer
    {
        public ObservableCollection<TabViewModel> Tabs { get; } = new ObservableCollection<TabViewModel>();

        TabViewModel selectedTab;

        public TabViewModel SelectedTab
        {
            get => selectedTab;
            set => OnPropertyChanged(out selectedTab, value);
        }

        public IEnumerable<ViewModelInfo> ViewModelInfos { get; }

        public MasterDataViewModel()
        {
            ViewModelInfos = new[]
            {
                new ViewModelInfo(() => CreateAndSubscribe(() => new ClassListViewModel(HonglornApi.Instance.ClassService())), "Classes"),
                new ViewModelInfo(() => CreateAndSubscribe(() => new CourseListViewModel(HonglornApi.Instance.CourseService())), "Courses"),
                new ViewModelInfo(() => CreateAndSubscribe(() => new StudentListViewModel(HonglornApi.Instance.StudentService())), "Students")
            };

            Tabs.CollectionChanged += Tabs_CollectionChanged;
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                SelectedTab = e.NewItems.Cast<TabViewModel>().First();
            }
        }

        private TabViewModel CreateAndSubscribe<TService, TEntity>(Func<NGListViewModel<TService, TEntity>> createViewModel)
            where TService : NGService<TEntity>
            where TEntity : Entity, new()
        {
            var viewModel = createViewModel();
            viewModel.OnCloseButtonPressed += ViewModel_OnCloseButtonPressed;
            viewModel.OnDetailViewModelCreated += ViewModel_OnDetailViewModelCreated;
            return viewModel;
        }

        private void ViewModel_OnDetailViewModelCreated(object sender, TabViewModelCreatedEventArgs e)
        {
            e.TabViewModel.OnCloseButtonPressed += ViewModel_OnCloseButtonPressed;
            Tabs.Add(e.TabViewModel);
        }

        private void ViewModel_OnCloseButtonPressed(object sender, EventArgs e)
        {
            Tabs.Remove((TabViewModel)sender);
        }
    }
}