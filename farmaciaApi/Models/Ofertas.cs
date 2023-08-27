using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace farmaciaApi.Models
{
    [Table("Ofertas")]
    public class Ofertas
    {
        [Key]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaValidez { get; set; }


    }
}
