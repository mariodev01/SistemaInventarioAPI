using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioAPI.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName ="date")]
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaVencimiento { get; set; }
        public int Cantidad { get; set; }
        [Precision(precision:18,scale:2)]
        public decimal Costo { get; set; }
    }
}
