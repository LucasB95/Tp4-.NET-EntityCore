using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class MyContextGlobal : DbContext
    {


        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Alojamiento> alojamientos { get; set; }

        public DbSet<Reserva> reservas { get; set; }

        public MyContextGlobal() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.num_usr);
            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr =>
                {
                    usr.Property(u => u.DNI).HasColumnType("int");
                    usr.Property(u => u.DNI).IsRequired(true);
                    usr.Property(u => u.Nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.Mail).HasColumnType("varchar(50)");
                    usr.Property(u => u.Password).HasColumnType("varchar(50)");
                    usr.Property(u => u.esAdmin).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                });



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


        }

    }
}
