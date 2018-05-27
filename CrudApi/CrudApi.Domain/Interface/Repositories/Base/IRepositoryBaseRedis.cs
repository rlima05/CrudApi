using System.Collections.Generic;

namespace CrudApi.Domain.Interface.Repositories
{
    public interface IRepositoryBaseRedis
    {

        void Add(string obj, string key);
        string GetByKey(string key);
        void Update(string obj, string key);
        void Remove(string key);


    }
}
