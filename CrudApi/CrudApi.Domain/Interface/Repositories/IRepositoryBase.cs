using System.Collections.Generic;

namespace CrudApi.Domain.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> 
    {

        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        

    }
}
