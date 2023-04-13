using SistemaInventarioAPI.Models;
using SistemaInventarioAPI.Repository.IRepository;

namespace SistemaInventarioAPI.Repository
{
    public class TransaccionRepository : Repository<Transaccion>, ITransaccion
    {
        private readonly SistemaDbContext context;

        public TransaccionRepository(SistemaDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<Transaccion> Update(Transaccion transaccion)
        {
            context.Transaccions.Update(transaccion);
            await context.SaveChangesAsync();
            return transaccion;
        }
    }
}
