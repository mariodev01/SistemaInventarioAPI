using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;
using System.Runtime.CompilerServices;

namespace SistemaInventarioAPI.Utilidades
{
    public class StoredProcedures : SistemaDbContext
    {
        //private readonly DbContextOptions<SistemaDbContext> _options;

        public StoredProcedures(DbContextOptions<SistemaDbContext> options) : base(options)
        {
            //_options = options;
        }
        public void RegistrarSalida(int id, int cant)
        {
            Database.ExecuteSqlRaw("exec sp_Salida {0},{1}", id, cant);
        }
        public void RegistrarEntrada(int id, int cant)
        {
            Database.ExecuteSqlRaw("exec sp_Entrada {0},{1}", id, cant);
        }
        public void ActualizarCosto(decimal costo, int id)
        {
            Database.ExecuteSqlRaw("exec sp_Total {0},{1}", costo, id);
        }
    }
}
