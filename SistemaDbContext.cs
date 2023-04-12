using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI
{
    public class SistemaDbContext:DbContext
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options):base(options)
        {

        }

        public DbSet<Articulo> Articulos { get; set; }



    }
}
