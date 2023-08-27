using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    public class FacturaDetalleModel
    {
        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int IdDetalle { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal Total { get; set; }
    }
}
