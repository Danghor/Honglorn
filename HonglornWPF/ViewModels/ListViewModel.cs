﻿using HonglornBL;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    abstract class ListViewModel<TManager, TDetailViewModel, TModel> : ViewModel
        where TManager : IEntityManager<TModel>, TModel
        where TDetailViewModel : DetailViewModel<TManager>, TModel
    {
        protected IEntityService<TManager, TModel> service;

        public ObservableCollection<TManager> Managers { get; } = new ObservableCollection<TManager>();
        public ICommand NewCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        TManager currentManager;
        public TManager CurrentManager
        {
            get => currentManager;
            set => OnPropertyChanged(out currentManager, value);
        }

        TDetailViewModel detailViewModel;
        public TDetailViewModel DetailViewModel
        {
            get => detailViewModel;
            set => OnPropertyChanged(out detailViewModel, value);
        }

        bool detailViewIsVisible;
        public bool DetailViewIsVisible
        {
            get => detailViewIsVisible;
            set => OnPropertyChanged(out detailViewIsVisible, value);
        }

        protected ListViewModel()
        {
            NewCommand = new RelayCommand(OpenDetailViewForCreate);
            EditCommand = new RelayCommand(OpenDetailViewForEdit);
            DeleteCommand = new RelayCommand(Delete);
        }

        protected void RefreshViewModel()
        {
            var managers = service.GetManagers();
            ClearAndFill(Managers, managers);
        }

        void Create()
        {
            service.Create(DetailViewModel);
            RefreshViewModel();
        }

        void Update()
        {
            CurrentManager.Update(DetailViewModel);
            RefreshViewModel();
        }

        void Delete()
        {
            service.Delete(CurrentManager);
            RefreshViewModel();
        }

        void OpenDetailViewForCreate()
        {
            DetailViewModel.Clear();
            DetailViewModel.AcceptCommand = new RelayCommand(() => { Create(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }

        void OpenDetailViewForEdit()
        {
            DetailViewModel.CopyValues(CurrentManager);
            DetailViewModel.AcceptCommand = new RelayCommand(() => { Update(); DetailViewIsVisible = false; });

            DetailViewIsVisible = true;
        }
    }
}