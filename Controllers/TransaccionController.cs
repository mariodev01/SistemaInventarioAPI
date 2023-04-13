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
    public class TransaccionController : ControllerBase
    {
        private readonly SistemaDbContext context;
        private readonly IMapper mapper;
        private readonly ITransaccion _tr;

        public TransaccionController(SistemaDbContext context,IMapper mapper,ITransaccion tr)
        {
            this.context = context;
            this.mapper = mapper;
            _tr = tr;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransaccionDTO>>> GetTransacciones()
        {
            var transacciones = await _tr.GetAll();

            //return mapper.Map<List<TransaccionDTO>>(transacciones);
            return Ok(transacciones);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<TransaccionDTO>> GetTransaccion(int id)
        {
            var transaccion = await _tr.GetById(id);
            if (transaccion==null)
            {
                return NotFound("No se encontro La transaccion con el id " + id);
            }

            return Ok(transaccion);
        }
        [HttpPost]
        public async Task<ActionResult> CreateTransaccion([FromBody] TransaccionCreateDTO transaccionDTO)
        {
            Transaccion modelo = mapper.Map<Transaccion>(transaccionDTO);

            await _tr.Create(modelo);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditTransaccion([FromBody] TransaccionCreateDTO createDTO,int id)
        {
            var existe = await _tr.GetById(id);

            if (existe== null)
            {
                return NotFound("no existe esa transaccion con ese id " + id);
            }

            Transaccion transaccion = mapper.Map<Transaccion>(createDTO);

            transaccion.Id= id;

            await _tr.Update(transaccion);
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTransaccion(int id)
        {
            var existe = await _tr.GetById(id);

            if (existe==null)
            {
                return NotFound("no existe esa transaccion con ese id " + id);
            }

            await _tr.Delete(id);
            return NoContent();
        }

    }
}
