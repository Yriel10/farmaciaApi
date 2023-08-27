using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Medicamento")]
    public class Medicamento
    {
     
        [Key]
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string NombreFabricante { get; set; }
        public int Codigo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public string? Foto { get; set; }
        public Boolean? TipoMedicamento { get; set; }
    }
}

    





    

