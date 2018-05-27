using CrudApi.Domain.Interface.Services;
using System.Linq;

namespace CrudApi.Domain.Services
{
    public class ReflectionService : IReflectionService
    {
        public string GetClassName(object obj)
        {            
            var type = obj.GetType();
            return type.Name;
        }

        public int GetObjectId(object obj)
        {
            var type = obj.GetType();
            var idFieldName = string.Concat(type, "Id");
            var splitNames = idFieldName.Split('.');
            var lastFieldName = splitNames.Last();
            var property = type.GetProperty(lastFieldName);

            return int.Parse(property.GetValue(obj).ToString());

        }

        public string GetPropertyName(object obj)
        {
            var type = obj.GetType();
            var idFieldName = string.Concat(type, "Id");
            var splitNames = idFieldName.Split('.');
            var lastFieldName = splitNames.Last();
            var property = type.GetProperty(lastFieldName);

            return property.Name;
        }
    }
}
