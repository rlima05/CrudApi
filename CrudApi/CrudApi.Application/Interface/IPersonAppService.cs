using CrudApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Application.Interface
{
    public interface IPersonAppService : IAppServiceBase<Person>
    {
    }
}
