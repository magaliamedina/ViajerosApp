﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViajerosApp.Data;

#nullable disable

namespace ViajerosApp.Migrations
{
    [DbContext(typeof(ViajerosDbContext))]
    partial class ViajerosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ViajerosApp.Models.Ciudad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("ViajerosApp.Models.TipoVehiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipoVehiculos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Descripcion = "Auto"
                        },
                        new
                        {
                            ID = 2,
                            Descripcion = "Camion"
                        },
                        new
                        {
                            ID = 3,
                            Descripcion = "Moto"
                        },
                        new
                        {
                            ID = 4,
                            Descripcion = "Colectivo"
                        },
                        new
                        {
                            ID = 5,
                            Descripcion = "Avion"
                        },
                        new
                        {
                            ID = 6,
                            Descripcion = "Otro"
                        });
                });

            modelBuilder.Entity("ViajerosApp.Models.Vehiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoVehiculoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipoVehiculoID");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ViajerosApp.Models.Viaje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CantidadDias")
                        .HasColumnType("int");

                    b.Property<int>("CiudadID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Reprogramado")
                        .HasColumnType("bit");

                    b.Property<int>("VehiculoID")
                        .HasColumnType("int");

                    b.Property<int>("ViajeroID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CiudadID");

                    b.HasIndex("VehiculoID");

                    b.HasIndex("ViajeroID");

                    b.ToTable("Viajes");
                });

            modelBuilder.Entity("ViajerosApp.Models.Viajero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CiudadID")
                        .HasColumnType("int");

                    b.Property<string>("NombreYApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CiudadID");

                    b.ToTable("Viajeros");
                });

            modelBuilder.Entity("ViajerosApp.Models.Vehiculo", b =>
                {
                    b.HasOne("ViajerosApp.Models.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("TipoVehiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("ViajerosApp.Models.Viaje", b =>
                {
                    b.HasOne("ViajerosApp.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViajerosApp.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ViajerosApp.Models.Viajero", "Viajero")
                        .WithMany()
                        .HasForeignKey("ViajeroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Vehiculo");

                    b.Navigation("Viajero");
                });

            modelBuilder.Entity("ViajerosApp.Models.Viajero", b =>
                {
                    b.HasOne("ViajerosApp.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadID");

                    b.Navigation("Ciudad");
                });
#pragma warning restore 612, 618
        }
    }
}
