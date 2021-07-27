using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Ordenes;

namespace Persistencia
{
    public class BodegaContext : DbContext
    {
        public DbSet<Bodega> Bodega { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Configuracion_Penalizacion> Configuracion_Penalizacions { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public BodegaContext() : base()
        {

        }

        public BodegaContext(DbContextOptions<BodegaContext>opciones) : base(opciones)
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (BodegaConfig.PersistenciaDestino)
                {
                    case "SQLServerEscuela":
                        optionsBuilder.UseSqlServer(BodegaConfig.connectionString);
                        break;
                    case "PostgresEscuela":
                        optionsBuilder.UseNpgsql(BodegaConfig.connectionString);
                        break;
                    case "memoriaEscuela":
                        optionsBuilder.UseInMemoryDatabase(BodegaConfig.connectionString);
                        break;
                }
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos; un Cliente tiene muchas ordenes 
            modelBuilder.Entity<Orden>()
                .HasOne(ord => ord.Cliente)
                .WithMany(cli => cli.Ordenes)
                .HasForeignKey(ord => ord.ClienteID);

            // Relación uno a uno; una Penalizacion tiene un estado
            modelBuilder.Entity<Estado>()
                .HasOne(est => est.Configuracion_Penalizacion)
                .WithOne(con => con.Estado)
                .HasForeignKey<Configuracion_Penalizacion>(con => con.EstadoID);

            // Relación uno a uno; una Bodega tiene una Ciudad
            modelBuilder.Entity<Ciudad>()
                .HasOne(ciu => ciu.Bodega)
                .WithOne(bod => bod.Ciudad)
                .HasForeignKey<Bodega>(bod => bod.CiudadID);

            // Relación uno a uno; un Producto tiene una Bodega
            modelBuilder.Entity<Bodega>()
                .HasOne(bod => bod.Producto)
                .WithOne(pro => pro.Bodega)
                .HasForeignKey<Producto>(pro => pro.BodegaID);

            // Relación uno a uno; una Orden tiene varios Estados
            modelBuilder.Entity<Orden>()
                .HasOne(ord => ord.Estado)
                .WithMany(est => est.Orden)
                .HasForeignKey(ord => ord.EstadoID);

            // Relación uno a uno; una Orden tiene un Producto
            modelBuilder.Entity<Producto>()
                .HasOne(pro => pro.Orden)
                .WithOne(ord => ord.Producto)
                .HasForeignKey<Orden>(ord => ord.ProductoID);

            // Relación uno a muchos; un Producto tiene muchas ordenes 
            //modelBuilder.Entity<Orden>()
            //    .HasOne(ord => ord.Producto)
            //    .WithMany(pro => pro.Ordenes)
            //    .HasForeignKey(ord => ord.ProductoID);


        }

        }

}
