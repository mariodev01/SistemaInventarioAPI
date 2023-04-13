using AutoMapper;
using SistemaInventarioAPI.Models;
using SistemaInventarioAPI.Models.DTO_s;

namespace SistemaInventarioAPI.Utilidades
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Articulo,ArticuloDTO>().ReverseMap();
            CreateMap<Articulo,ArticuloCreateDTO>().ReverseMap();

            CreateMap<Transaccion,TransaccionDTO>().ReverseMap();
            CreateMap<Transaccion,TransaccionCreateDTO>().ReverseMap();
        }
    }
}
