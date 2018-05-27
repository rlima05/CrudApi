using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Application.Interface
{
    public interface IAppServiceBaseRedis<T>
    {
        void Add(T obj);
        T GetByKey(int id);
        void Update(T obj);
        void Remove(int id);
    }
}
