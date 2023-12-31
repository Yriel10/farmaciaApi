﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmaciaApi.Models
{
    [Table("Factura")]
    public class Factura
    {

        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
    }
}
