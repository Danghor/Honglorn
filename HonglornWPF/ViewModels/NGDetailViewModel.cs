using HonglornBL.MasterData;
using HonglornBL.Models.Entities;
using System;
using System.Data.Entity.Core.Objects;

namespace HonglornWPF.ViewModels
{
    abstract class NGDetailViewModel<TService, TEntity> : ServiceViewModel<TService, TEntity>
        where TService : NGService<TEntity>
        where TEntity : Entity
    {
        private TEntity entity;

        public TEntity Entity
        {
            get => entity;
            set => OnPropertyChanged(out entity, value);
        }

        protected NGDetailViewModel(TService service, Guid entityKey) : base(service)
        {
            Entity = Service.Find(entityKey);

            Entity.PropertyChanged += Entity_PropertyChanged;
            Service.ContextChanged += Service_ContextChanged;

            RefreshTabTitle();
        }

        private void Entity_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RefreshTabTitle();
        }

        private void RefreshTabTitle()
        {
            TabTitle = $"{ObjectContext.GetObjectType(Entity.GetType()).Name} - {Entity}";
        }

        private void Service_ContextChanged(object sender, ContextChangedEventArgs e)
        {
            Entity = Service.Find(Entity.PKey);
        }
    }
}
