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
    [Migration("20240204002546_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("Relaciones.Models.RelacionMuchos", b =>
                {
                    b.HasOne("Relaciones.Models.RelacionUno", "RelacionUno")
                        .WithMany("RelacionMuchos")
                        .HasForeignKey("RelacionUnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelacionUno");
                });

            modelBuilder.Entity("Relaciones.Models.RelacionUno", b =>
                {
                    b.Navigation("RelacionMuchos");
                });
#pragma warning restore 612, 618
        }
    }
}