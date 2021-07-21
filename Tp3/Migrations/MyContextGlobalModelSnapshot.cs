﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp3;

namespace Tp3.Migrations
{
    [DbContext(typeof(MyContextGlobal))]
    partial class MyContextGlobalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tp3.Alojamiento", b =>
                {
                    b.Property<int>("pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("barrio")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("baños")
                        .HasColumnType("int");

                    b.Property<int>("cantPersonas")
                        .HasColumnType("int");

                    b.Property<string>("ciudad")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("codigo")
                        .HasColumnType("int");

                    b.Property<int>("estrellas")
                        .HasColumnType("int");

                    b.Property<int>("habitaciones")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("precioDia")
                        .HasColumnType("int");

                    b.Property<int>("precioPorPersona")
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("tv")
                        .HasColumnType("bit");

                    b.HasKey("pk");

                    b.ToTable("Alojamientos");
                });

            modelBuilder.Entity("Tp3.Reserva", b =>
                {
                    b.Property<int>("pk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fdesde")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("fhasta")
                        .HasColumnType("datetime");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("personaint")
                        .HasColumnType("int");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.Property<int>("propiedadint")
                        .HasColumnType("int");

                    b.HasKey("pk");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Tp3.Usuario", b =>
                {
                    b.Property<int>("num_usr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("bit");

                    b.HasKey("num_usr");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
