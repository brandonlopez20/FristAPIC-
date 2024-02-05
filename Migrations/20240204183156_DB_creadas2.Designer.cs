﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Relaciones;

#nullable disable

namespace Relaciones.Migrations
{
    [DbContext(typeof(AplicationDBContext))]
    [Migration("20240204183156_DB_creadas2")]
    partial class DB_creadas2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Relaciones.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Relaciones.Models.Presentacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Presentaciones");
                });

            modelBuilder.Entity("Relaciones.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Iva")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.Property<int>("PresentacionId")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.Property<int>("codigo")
                        .HasColumnType("int");

                    b.Property<double>("peso")
                        .HasColumnType("double");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("PresentacionId");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("ZonaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Relaciones.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Relaciones.Models.RelacionMuchos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RelacionUnoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelacionUnoId");

                    b.ToTable("RelacionesMuchos");
                });

            modelBuilder.Entity("Relaciones.Models.RelacionUno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RelacionesUno");
                });

            modelBuilder.Entity("Relaciones.Models.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Zonas");
                });

            modelBuilder.Entity("Relaciones.Models.Producto", b =>
                {
                    b.HasOne("Relaciones.Models.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Relaciones.Models.Presentacion", "Presentacion")
                        .WithMany("Productos")
                        .HasForeignKey("PresentacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Relaciones.Models.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Relaciones.Models.Zona", "Zona")
                        .WithMany("Productos")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Presentacion");

                    b.Navigation("Proveedor");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("Relaciones.Models.RelacionMuchos", b =>
                {
                    b.HasOne("Relaciones.Models.RelacionUno", "RelacionUno")
                        .WithMany("RelacionMuchos")
                        .HasForeignKey("RelacionUnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelacionUno");
                });

            modelBuilder.Entity("Relaciones.Models.Marca", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Relaciones.Models.Presentacion", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Relaciones.Models.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Relaciones.Models.RelacionUno", b =>
                {
                    b.Navigation("RelacionMuchos");
                });

            modelBuilder.Entity("Relaciones.Models.Zona", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
