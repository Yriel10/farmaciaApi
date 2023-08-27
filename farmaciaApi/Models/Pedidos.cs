using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Pedidos")]
    public class Pedidos
    {
        [Key]
        public int IdPedido { get; set; }
        public string Nombre { get; set; }

        public string LugarEntrega { get; set; }
        public string Estado { get; set; }

        [ForeignKey("Factura")]
        public int IdFactura { get; set; }
    }
}
