using System;
using HonglornBL.Models.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HonglornBL.MasterData;
using HonglornBL.Models.Entities;

namespace HonglornWPF.ViewModels
{
    internal abstract class ServiceViewModel<TService, TEntity> : TabViewModel, IDisposable
        where TService : NGService<TEntity>
        where TEntity : Entity
    {
        public ICommand SaveCommand { get; }
        public ICommand RefreshCommand { get; }

        protected TService Service { get; }

        protected ServiceViewModel(TService service)
        {
            Service = service;
            SaveCommand = new RelayCommand(Save);
            RefreshCommand = new RelayCommand(Refresh);
        }

        protected void Save()
        {
            Service.SaveChanges();
        }

        protected virtual void Refresh()
        {
            Service.RefreshContext();
        }

        public void Dispose()
        {
            Service.Dispose();
        }

        protected static void ClearAndFill<TT>(ICollection<TT> collection, IEnumerable<TT> content)
        {
            collection.Clear();

            foreach (var item in content)
            {
                collection.Add(item);
            }
        }
    }
}
