using System;
using System.Collections.Generic;
using System.Linq;
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        private CrudApiContext Db;
        private readonly IReflectionService _reflectionService;

        public RepositoryBase(CrudApiContext db, IReflectionService reflectionService)
        {
            Db = db;
            _reflectionService = reflectionService;
        }

        public int Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();

            return _reflectionService.GetObjectId(obj);
        }

        

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            Db.Set<T>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

       
    }
}
