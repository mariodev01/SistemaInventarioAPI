using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Repository.IRepository;

namespace SistemaInventarioAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SistemaDbContext context;

        public Repository(SistemaDbContext context)
        {
            this.context = context;
        }
        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var modelo = await context.Set<T>().FindAsync(id);

            if (modelo != null)
            {
                context.Set<T>().Remove(modelo);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);

            await context.SaveChangesAsync();
        }
    }
}
