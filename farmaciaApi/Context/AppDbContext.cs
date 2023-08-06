using farmaciaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace farmaciaApi.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<farmaciaApi.Models.Factura>? Factura { get; set; }
      
    }

  
}
