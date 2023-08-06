using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Multimedia")]
    public class Multimedia
    {
        [Key]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }


    }
}
