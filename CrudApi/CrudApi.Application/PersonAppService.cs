using System.Collections.Generic;
using CrudApi.Application.Interface;
using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Services;

namespace CrudApi.Application
{
    public class PersonAppService : AppServiceBase<Person>, IPersonAppService
    {
        public PersonAppService(IServiceBase<Person> serviceBase) : base(serviceBase)
        {
        }
    }
}
