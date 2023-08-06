using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public string Categoria { get; set; }
        public string NombreProducto { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("Medicamento")]
        public int IdMedicamento { get; set; }

    }
}
