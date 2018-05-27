using CrudApi.Domain.Interface.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace CrudApi.Infra.Repositories
{
    public class RepositoryBaseRedis: IRepositoryBaseRedis
    {
        private readonly IDistributedCache _cache;

        public RepositoryBaseRedis(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void Add(string obj, string key)
        {
            _cache.SetString(key, obj);
        }

        public string GetByKey(string key)
        {
            return _cache.GetString(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Update(string obj, string key)
        {
            Remove(key);
            Add(obj, key);
        }
    }
}
