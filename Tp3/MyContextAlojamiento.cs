using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class MyContextAlojamiento : DbContext
    {
        public DbSet<Alojamiento> alojamientos { get; set; }
        public MyContextAlojamiento() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Alojamiento>()
                .ToTable("Alojamientos")
                .HasKey(u => u.pk);
            //propiedades de los datos
            modelBuilder.Entity<Alojamiento>(
                aloj =>
                {
                    aloj.Property(u => u.codigo).HasColumnType("int");
                    aloj.Property(u => u.codigo).IsRequired(true);
                    aloj.Property(u => u.tipo).HasColumnType("varchar(50)");
                    aloj.Property(u => u.barrio).HasColumnType("varchar(50)");
                    aloj.Property(u => u.ciudad).HasColumnType("varchar(50)");
                    aloj.Property(u => u.estrellas).HasColumnType("int");
                    aloj.Property(u => u.cantPersonas).HasColumnType("int");
                    aloj.Property(u => u.tv).HasColumnType("bit");
                    aloj.Property(u => u.precioDia).HasColumnType("int");
                    aloj.Property(u => u.precioPorPersona).HasColumnType("int");
                    aloj.Property(u => u.habitaciones).HasColumnType("int");
                    aloj.Property(u => u.baños).HasColumnType("int");
                    aloj.Property(u => u.nombre).HasColumnType("varchar(50)");

                });
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<AgenciaManager>();
            modelBuilder.Ignore<Agencia>();
        }
    }
}
