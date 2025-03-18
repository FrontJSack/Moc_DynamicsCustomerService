﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moc_DynamicCustomerService.Data;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250318115343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Konto.Konto", b =>
                {
                    b.Property<int>("kontoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("branza")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dataModyfikacji")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dataUtworzenia")
                        .HasColumnType("TEXT");

                    b.Property<string>("emailGlowny")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("kraj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("miasto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nazwaFirmy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefonGlowny")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("kontoId");

                    b.ToTable("Konta");
                });
#pragma warning restore 612, 618
        }
    }
}
