using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Notificaciones")]
    public class Notificaiones
    {
        [Key]
        public int IdNotificaciones { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }


  
    }
}
