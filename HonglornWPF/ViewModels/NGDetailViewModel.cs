﻿using HonglornBL.MasterData;
using HonglornBL.Models.Entities;
using System;

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

            Service.ContextChanged += Service_ContextChanged;
        }

        private void Service_ContextChanged(object sender, ContextChangedEventArgs e)
        {
            Entity = Service.Find(Entity.PKey);
        }
    }
}
