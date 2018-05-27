using CrudApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Domain.Interface.Services
{
    public interface IPersonServiceRedis: IServiceBaseRedis<Person>
    {
    }
}
