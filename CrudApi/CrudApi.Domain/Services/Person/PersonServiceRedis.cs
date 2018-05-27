using CrudApi.Domain.Entities;
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Domain.Services
{
    public class PersonServiceRedis : ServiceBaseRedis<Person>, IPersonServiceRedis
    {
        public PersonServiceRedis(IRepositoryBaseRedis repository, IReflectionService reflectionServices, IRepositoryBase<Person> repositoryBase) : base(repository, reflectionServices, repositoryBase)
        {
        }
    }
}
