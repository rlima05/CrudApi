using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Repositories;

namespace CrudApi.Infra.Repositoies
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(CrudApiContext db) : base(db)
        {
        }
    }
}
