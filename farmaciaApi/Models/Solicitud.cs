using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Solicitud")]
    public class Solicitud
    {

        [Key]
        public int IdSolicitud { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }

        public string Estado { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
    }
}
