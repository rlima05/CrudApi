using System;
using System.Collections.Generic;
using System.Linq;
using CrudApi.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Infra.Repositoies
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        private CrudApiContext Db;

        public RepositoryBase(CrudApiContext db)
        {
            Db = db;
        }

        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
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
