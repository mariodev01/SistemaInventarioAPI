using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioAPI.Models
{
    public class TipoTransaccion
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Descripcion { get; set; }
    }
}
