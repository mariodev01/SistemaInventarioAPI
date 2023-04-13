namespace SistemaInventarioAPI.Repository.IRepository
{
    public interface IRepository<T> where T :class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
