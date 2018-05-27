using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;
using Newtonsoft.Json;
using System.Linq;

namespace CrudApi.Domain.Services
{
    public class ServiceBaseRedis<T> : IServiceBaseRedis<T> where T : class
    {
        private readonly IRepositoryBaseRedis _repository;
        private readonly IReflectionService _reflectionService;
        private readonly IRepositoryBase<T> _repositoryBase;
        


        public ServiceBaseRedis(IRepositoryBaseRedis repository, IReflectionService reflectionServices, IRepositoryBase<T> repositoryBase)
        {
            _repository = repository;
            _reflectionService = reflectionServices;
            _repositoryBase = repositoryBase;

            
        }

        public void Add(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var id = _reflectionService.GetObjectId(obj);
            _repository.Add(json, id.ToString());
        }

        public T GetByKey(int id)
        {
            var json = _repository.GetByKey(id.ToString());
            
            //If there's no data in Cache get from DB
            var model = json == null? _repositoryBase.GetById(id) : JsonConvert.DeserializeObject<T>(json);

            return model;
        }

        public void Remove(int id)
        {
            _repository.Remove(id.ToString());
        }

        public void Update(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var id = _reflectionService.GetObjectId(obj); 
            _repository.Update(json, id.ToString());
        }
    }
}
