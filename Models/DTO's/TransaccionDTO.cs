using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioAPI.Models.DTO_s
{
    public class TransaccionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey("Id")]
        public int TipoTransaccionId { get; set; }
        [ForeignKey("Id")]
        public int ArticuloId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaDocumento { get; set; }
        [ForeignKey("Id")]
        public int EstadoId { get; set; }
        public int Cantidad { get; set; }
        [Precision(precision: 18, scale: 2)]
        public decimal CostoTotal { get; set; }
    }
}
