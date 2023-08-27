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
        public DbSet<farmaciaApi.Models.Ofertas>? Ofertas { get; set; }
        public DbSet<farmaciaApi.Models.Notificaiones>? Notificaiones { get; set; }
        public DbSet<farmaciaApi.Models.Solicitud>? Solicitud { get; set; }
        public DbSet<farmaciaApi.Models.Pedidos>? Pedidos { get; set; }
        public DbSet<farmaciaApi.Models.Detalle>? Detalle { get; set; }
        public DbSet<farmaciaApi.Models.Factura>? Factura { get; set; }

        public DbSet<farmaciaApi.Models.FacturaDetalleModel> DetalleModels { get; set; }



    }


}
