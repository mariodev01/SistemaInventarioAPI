using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Repository.IRepository
{
    public interface ITransaccion : IRepository<Transaccion>
    {
        Task<Transaccion> Update(Transaccion transaccion);
    }
}
