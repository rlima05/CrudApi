using CrudApi.Application.Interface;
using CrudApi.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Application
{
    public class AppServiceBaseRedis<T> : IAppServiceBaseRedis<T> where T : class
    {
        private readonly IServiceBaseRedis<T> _service;

        public AppServiceBaseRedis(IServiceBaseRedis<T> service)
        {
            _service = service;
        }

        public void Add(T obj)
        {
            _service.Add(obj);
        }

        public T GetByKey(int id)
        {
            return _service.GetByKey(id);
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Update(T obj)
        {
            _service.Update(obj);
        }
    }
}
