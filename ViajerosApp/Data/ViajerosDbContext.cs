using Microsoft.EntityFrameworkCore;
using ViajerosApp.Models;

namespace ViajerosApp.Data
{
    public class ViajerosDbContext : DbContext
    {
        public DbSet<Viajero> Viajeros { get; set; }

        public DbSet<Viaje> Viajes { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ViajerosApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 1, Descripcion = "Auto"});
            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 2, Descripcion = "Camion" });
            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 3, Descripcion = "Moto" });
            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 4, Descripcion = "Colectivo" });
            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 5, Descripcion = "Avion" });
            modelBuilder.Entity<TipoVehiculo>().HasData(
                   new TipoVehiculo { ID = 6, Descripcion = "Otro" });

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
