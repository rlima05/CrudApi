using CrudApi.Application.Interface;
using CrudApi.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T>
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(T obj)
        {
            _serviceBase.Add(obj);
        }

        public T GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(T obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(T obj)
        {
            _serviceBase.Remove(obj);
        }

        
    }
}
