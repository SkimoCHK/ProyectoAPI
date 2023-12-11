﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoAPI.Data;

namespace ProyectoAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231211150503_OneToManyRelationship")]
    partial class OneToManyRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoAPI.Data.Models.Carrera", b =>
                {
                    b.Property<int>("IDCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCarrera");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Edificio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Edificio");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Instalacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdificioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EdificioID");

                    b.ToTable("Instalacion");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApeMa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApePa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("InstalacionID")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstalacionID");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Instalacion", b =>
                {
                    b.HasOne("ProyectoAPI.Data.Models.Edificio", "edificio")
                        .WithMany("Instalaciones")
                        .HasForeignKey("EdificioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("edificio");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Profesor", b =>
                {
                    b.HasOne("ProyectoAPI.Data.Models.Carrera", "Carrera")
                        .WithMany("Profesores")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Reserva", b =>
                {
                    b.HasOne("ProyectoAPI.Data.Models.Instalacion", "instalacion")
                        .WithMany("Reservas")
                        .HasForeignKey("InstalacionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoAPI.Data.Models.Profesor", "profesor")
                        .WithMany("Reservas")
                        .HasForeignKey("ProfesorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("instalacion");

                    b.Navigation("profesor");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Carrera", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Edificio", b =>
                {
                    b.Navigation("Instalaciones");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Instalacion", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ProyectoAPI.Data.Models.Profesor", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}