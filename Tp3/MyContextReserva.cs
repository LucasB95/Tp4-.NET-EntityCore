using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class MyContextReserva : DbContext
    {
        public DbSet<Reserva> reservas { get; set; }
        public MyContextReserva() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Reserva>()
                .ToTable("Reserva")
                .HasKey(u => u.pk);
            //propiedades de los datos
            modelBuilder.Entity<Reserva>(
                usr =>
                {
                    usr.Property(u => u.id).HasColumnType("int");
                    usr.Property(u => u.id).IsRequired(true);
                    usr.Property(u => u.fdesde).HasColumnType("datetime");
                    usr.Property(u => u.fhasta).HasColumnType("datetime");
                    usr.Property(u => u.precio).HasColumnType("int");
                    usr.Property(u => u.propiedadint).HasColumnType("int");
                    usr.Property(u => u.personaint).HasColumnType("int");
                });
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<AgenciaManager>();
            modelBuilder.Ignore<Agencia>();
        }
    }
}
