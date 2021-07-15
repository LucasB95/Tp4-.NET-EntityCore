using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp3
{
    class MyContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public MyContext() { }

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
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<AgenciaManager>();
            modelBuilder.Ignore<Agencia>();     
        }
    }
}
