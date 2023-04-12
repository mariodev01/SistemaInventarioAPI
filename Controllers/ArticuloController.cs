using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly SistemaDbContext context;

        public ArticuloController(SistemaDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Articulo>>> GetArticulos()
        {
            var articulos = await context.Articulos.ToListAsync();
            return articulos;
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
            if (articulo == null)
            {
                return NotFound("No se encontro Articulo con el id " + id);
            }

            return Ok(articulo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateArticulo([FromBody] Articulo articulo)
        {
            var existeArticulo = await context.Articulos.AnyAsync(a => a.Descripcion == articulo.Descripcion);

            if (existeArticulo)
            {
                return BadRequest("Ya existe un Articulo con ese Nombre ");
            }

            await context.AddAsync(articulo);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> EditArticulo([FromBody] Articulo articulo, int id)
        {
            var existeArticulo = await context.Articulos.AnyAsync(a => a.Id == id);

            if (!existeArticulo)
            {
                return NotFound("no existe articulo con el id " + id);
            }

            articulo.Id = id;

            context.Update(articulo);
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteArticulo(int id)
        {
            var existeArticulo = await context.Articulos.AnyAsync(a=>a.Id== id);

            if (!existeArticulo)
            {
                return NotFound("no existe articulo con el id " + id);
            }

            context.Remove(new Articulo { Id=id});
            await context.SaveChangesAsync();
            return NoContent();

        }


    }
}
