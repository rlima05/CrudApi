using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApi.Domain.Interface.Services
{
    public interface IReflectionService
    {
        int GetObjectId(object obj);
        string GetPropertyName(object obj);
        string GetClassName(object obj);
    }
}
