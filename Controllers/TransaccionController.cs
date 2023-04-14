using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;
using SistemaInventarioAPI.Models.DTO_s;
using SistemaInventarioAPI.Repository.IRepository;
using SistemaInventarioAPI.Utilidades;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly SistemaDbContext context;
        private readonly IMapper mapper;
        private readonly ITransaccion _tr;
        private readonly StoredProcedures stored;

        public TransaccionController(SistemaDbContext context,IMapper mapper,ITransaccion tr,StoredProcedures stored)
        {
            this.context = context;
            this.mapper = mapper;
            _tr = tr;
            this.stored = stored;
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
            if(ModelState.IsValid)
            {
                await _tr.Create(modelo);
                var Tultimo = context.Transaccions.OrderByDescending(t => t.Id).Take(1).FirstOrDefault();
                if (Tultimo.TipoTransaccionId == 1)
                {
                    var costo = context.Articulos.Where(a => a.Id == Tultimo.ArticuloId).FirstOrDefault();
                    var costoT = costo.Costo * Tultimo.Cantidad;

                    stored.RegistrarEntrada(Tultimo.ArticuloId, Tultimo.Cantidad);
                    stored.ActualizarCosto(costoT, Tultimo.Id);
                }else if (Tultimo.TipoTransaccionId == 2)
                {
                    var costo = context.Articulos.Where(a => a.Id == Tultimo.ArticuloId).FirstOrDefault();
                    var costoT = costo.Costo * Tultimo.Cantidad;
                    stored.RegistrarSalida(Tultimo.ArticuloId, Tultimo.Cantidad);
                    stored.ActualizarCosto(costoT, Tultimo.Id);
                }
            }
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
            if (ModelState.IsValid)
            {
                await _tr.Update(transaccion);
                var Tultimo = context.Transaccions.OrderByDescending(t => t.Id).Take(1).FirstOrDefault();
                if (Tultimo.TipoTransaccionId == 1)
                {
                    var costo = context.Articulos.Where(a => a.Id == Tultimo.ArticuloId).FirstOrDefault();
                    var costoT = costo.Costo * Tultimo.Cantidad;

                    stored.RegistrarEntrada(Tultimo.ArticuloId, Tultimo.Cantidad);
                    stored.ActualizarCosto(costoT, Tultimo.Id);
                }
                else if (Tultimo.TipoTransaccionId == 2)
                {
                    var costo = context.Articulos.Where(a => a.Id == Tultimo.ArticuloId).FirstOrDefault();
                    var costoT = costo.Costo * Tultimo.Cantidad;
                    stored.RegistrarSalida(Tultimo.ArticuloId, Tultimo.Cantidad);
                    stored.ActualizarCosto(costoT, Tultimo.Id);
                }
            }
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
