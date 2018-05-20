using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;

namespace CrudApi.Domain.Services
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        public PersonService(IRepositoryBase<Person> repository) : base(repository)
        {
        }
    }
}
