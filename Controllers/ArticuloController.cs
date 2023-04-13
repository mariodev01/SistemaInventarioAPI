using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;
using SistemaInventarioAPI.Models.DTO_s;
using SistemaInventarioAPI.Repository.IRepository;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly SistemaDbContext context;
        private readonly IMapper mapper;
        private readonly IArticulo _articulo;

        public ArticuloController(SistemaDbContext context,IMapper mapper,IArticulo articulo)
        {
            this.context = context;
            this.mapper = mapper;
            _articulo = articulo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticuloDTO>>> GetArticulos()
        {
            var articulos = await _articulo.GetAll();
            //return mapper.Map<List<ArticuloDTO>>(articulos);

            return Ok(articulos);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ArticuloDTO>> GetArticulo(int id)
        {
            var articulo = await _articulo.GetById(id);
            if (articulo == null)
            {
                return NotFound("No se encontro Articulo con el id " + id);
            }

            return Ok(articulo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateArticulo([FromBody] ArticuloCreateDTO articuloCreate)
        {
            Articulo modelo = mapper.Map<Articulo>(articuloCreate);

            await _articulo.Create(modelo);
            return NoContent();
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> EditArticulo([FromBody] ArticuloCreateDTO articuloCreate, int id)
        {
            var articulo = await _articulo.GetById(id);

            if (articulo == null)
            {
                return NotFound();
            }

            Articulo modelo = mapper.Map<Articulo>(articuloCreate);
            modelo.Id = id;
            await _articulo.Update(modelo);
            return NoContent();
            
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteArticulo(int id)
        {
            var articulo = await _articulo.GetById(id);
            if (articulo == null)
            {
                return NotFound(); 
            }

            await _articulo.Delete(id);
            return NoContent();
        }
    }
}
