using SistemaInventarioAPI.Models;
using SistemaInventarioAPI.Repository.IRepository;

namespace SistemaInventarioAPI.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticulo
    {
        private readonly SistemaDbContext context;

        public ArticuloRepository(SistemaDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<Articulo> Update(Articulo articulo)
        {
            context.Articulos.Update(articulo);
            await context.SaveChangesAsync();
            return articulo;
        }
    }
}
