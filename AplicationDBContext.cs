using Microsoft.EntityFrameworkCore;
using Relaciones.Models;

namespace Relaciones
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<RelacionUno> RelacionesUno { get; set; }
        public DbSet<RelacionMuchos> RelacionesMuchos { get; set; }

        //BASES DE DATOS

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Presentacion> Presentaciones { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Zona> Zonas { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación uno a muchos
 
        }

    }
}
