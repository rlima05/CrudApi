using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;

namespace CrudApi.Infra.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(CrudApiContext db, IReflectionService reflectionService) : base(db, reflectionService)
        {
        }
    }
}
