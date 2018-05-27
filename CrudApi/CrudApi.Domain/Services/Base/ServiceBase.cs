﻿
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T>
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public int Add(T obj)
        {
            return _repository.Add(obj);
        }



        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
