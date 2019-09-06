using HonglornBL.MasterData;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    // TODO: Rename
    abstract class NGListViewModel<TService, TEntity> : ServiceViewModel<TService, TEntity>
        where TService : NGService<TEntity>
        where TEntity : Entity, new()
    {
        internal event EventHandler<TabViewModelCreatedEventArgs> OnDetailViewModelCreated;

        public ICommand DeleteCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand EditCommand { get; }

        public ObservableCollection<TEntity> Entities { get; } = new ObservableCollection<TEntity>();

        TEntity selectedEntity;

        public TEntity SelectedEntity
        {
            get => selectedEntity;
            set => OnPropertyChanged(out selectedEntity, value);
        }

        protected NGListViewModel(TService service) : base(service)
        {
            DeleteCommand = new RelayCommand(Delete);
            NewCommand = new RelayCommand(OpenDetailViewForCreate);
            EditCommand = new RelayCommand(OpenDetailViewForEdit);

            Service.ContextChanged += Service_ContextChanged;
        }

        private void Service_ContextChanged(object sender, ContextChangedEventArgs e)
        {
            ClearAndFill(Entities, Service.GetAll());
        }

        void Delete()
        {
            Service.Delete(SelectedEntity);
            Save();
            Refresh();
        }

        void OpenDetailViewForCreate()
        {
            var newEntity = new TEntity();
            Service.AddNewEntity(newEntity);

            var detailViewModel = CreateDetailViewModel(Service, newEntity.PKey);

            OnDetailViewModelCreated?.Invoke(this, new TabViewModelCreatedEventArgs(detailViewModel));
        }

        protected abstract NGDetailViewModel<TService, TEntity> CreateDetailViewModel(TService service, Guid entityKey);

        void OpenDetailViewForEdit()
        {
            var detailViewModel = CreateDetailViewModel(Service, SelectedEntity.PKey);

            OnDetailViewModelCreated?.Invoke(this, new TabViewModelCreatedEventArgs(detailViewModel));
        }
    }
}
