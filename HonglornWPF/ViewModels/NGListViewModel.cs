using HonglornBL.MasterData;
using HonglornBL.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    // TODO: Rename
    abstract class NGListViewModel<T> : ViewModel
        where T : class, new()
    {
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand EditCommand { get; }

        public ObservableCollection<T> Entities { get; } = new ObservableCollection<T>();

        T currentEntity;
        public T CurrentEntity
        {
            get => currentEntity;
            set => OnPropertyChanged(out currentEntity, value);
        }

        NGDetailViewModel<T> detailViewModel;
        public NGDetailViewModel<T> DetailViewModel
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

        protected abstract NGService<T> Service { get; }

        protected NGListViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
            NewCommand = new RelayCommand(OpenDetailViewForCreate);
            EditCommand = new RelayCommand(OpenDetailViewForEdit);
        }

        void Delete()
        {
            Service.Delete(CurrentEntity);
            SaveAndRefresh();
        }

        void OpenDetailViewForCreate()
        {
            var newEntity = new T();
            DetailViewModel = CreateDetailViewModel(
                () => DetailViewIsVisible = false,
                () =>
                {
                    Service.Create(newEntity);
                    SaveAndRefresh();
                    CloseDetailView();
                },
                newEntity);

            DetailViewIsVisible = true;
        }

        protected abstract NGDetailViewModel<T> CreateDetailViewModel(Action cancelAction, Action acceptAction, T entity);

        void OpenDetailViewForEdit()
        {
            DetailViewModel = CreateDetailViewModel(
            () =>
            {
                Service.DiscardObjectChanges(currentEntity);
                CloseDetailView();
            },
            () =>
            {
                SaveAndRefresh();
                CloseDetailView();
            },
            currentEntity);

            DetailViewIsVisible = true;
        }

        void SaveAndRefresh()
        {
            Service.SaveChanges();
            Refresh();
        }

        public void Refresh()
        {
            Service.RefreshContext();
            ClearAndFill(Entities, Service.GetAll());
        }

        void CloseDetailView()
        {
            DetailViewIsVisible = false;
        }
    }
}
