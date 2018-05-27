namespace CrudApi.Domain.Interface.Services
{
    public interface IServiceBaseRedis<T>
    {
        void Add(T obj);
        T GetByKey(int id);
        void Update(T obj);
        void Remove(int id);
    }
}
