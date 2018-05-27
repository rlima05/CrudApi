using System.Collections.Generic;

namespace CrudApi.Application.Interface
{
    public interface IAppServiceBase<T>
    {
        int Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
