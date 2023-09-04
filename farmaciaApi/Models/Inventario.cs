using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Inventario")]
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        public string NombreProducto { get; set; }
        public DateTime FechaEntrada { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int CantidadEntregada { get; set; }
        public int Codigo { get; set; }

        public string Fabricante { get; set; }

        public string Estado { get; set; }
    }
}
