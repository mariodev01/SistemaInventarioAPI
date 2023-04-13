using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Repository.IRepository
{
    public interface IArticulo: IRepository<Articulo>
    {
        Task<Articulo> Update(Articulo articulo);
    }
}
