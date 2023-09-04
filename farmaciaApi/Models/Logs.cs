using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Logs")]
    public class Logs
    {
        [Key]
        public int IdLogs { get; set; }
        public string Accion { get; set; }
         public string Tabla { get; set; }
        public int Registro { get; set; }

        public string Campo { get; set; }
        public string ValorAntes { get; set; }
        public string ValorDespues { get; set; }

        public DateTime Fecha { get; set; }

        public string Usuario { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
    }
}
