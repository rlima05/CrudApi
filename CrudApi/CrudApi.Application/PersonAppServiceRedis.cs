using System.Collections.Generic;
using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Services;

namespace CrudApi.Application.Interface
{
    public class PersonAppServiceRedis : AppServiceBaseRedis<Person>, IPersonAppServiceRedis
    {
        public PersonAppServiceRedis(IServiceBaseRedis<Person> serviceRedis)
            :base(serviceRedis)
        {

        }
        
    }
}
