using System.Collections.Generic;

namespace CrudApi.Application.Interface
{
    public interface IAppServiceBase<T>
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
