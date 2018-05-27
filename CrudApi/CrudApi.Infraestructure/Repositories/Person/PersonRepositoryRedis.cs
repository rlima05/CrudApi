using CrudApi.Domain.Interface.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace CrudApi.Infra.Repositories
{
    public class PersonRepositoryRedis : RepositoryBaseRedis, IPersonRepositoryRedis
    {
        public PersonRepositoryRedis(IDistributedCache cache) : base(cache)
        {
        }
    }
}
