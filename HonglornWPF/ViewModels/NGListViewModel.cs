using HonglornBL.MasterData;
using HonglornBL.Models.Framework;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HonglornWPF.ViewModels
{
    // TODO: Rename
    abstract class NGListViewModel<T> : ContextViewModel
        where T : class, new()
    {
        internal event EventHandler<DetailViewModelCreatedEventArgs<T>> OnDetailViewModelCreated;

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

        protected abstract NGService<T> Service { get; }

        protected NGListViewModel(HonglornDb context) : base(context)
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
            var detailViewModel = CreateDetailViewModel(
                () => { }, //DetailViewIsVisible = false,
                () =>
                {
                    Service.Create(newEntity);
                    SaveAndRefresh();
                    //CloseDetailView();
                },
                newEntity);

            OnDetailViewModelCreated?.Invoke(this, new DetailViewModelCreatedEventArgs<T>(detailViewModel));
        }

        protected abstract NGDetailViewModel<T> CreateDetailViewModel(Action cancelAction, Action acceptAction, T entity);

        void OpenDetailViewForEdit()
        {
            var detailViewModel = CreateDetailViewModel(
            () =>
            {
                Service.DiscardObjectChanges(currentEntity);
                //CloseDetailView();
            },
            () =>
            {
                SaveAndRefresh();
                //CloseDetailView();
            },
            currentEntity);

            OnDetailViewModelCreated?.Invoke(this, new DetailViewModelCreatedEventArgs<T>(detailViewModel));
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
    }
}
