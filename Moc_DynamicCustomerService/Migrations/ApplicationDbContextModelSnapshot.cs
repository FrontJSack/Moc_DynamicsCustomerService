﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moc_DynamicCustomerService.Data;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Kontakt", b =>
                {
                    b.Property<int>("kontaktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("data_modyfikacji")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("data_utworzenia")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("imie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("kontoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nazwisko")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("kontaktId");

                    b.HasIndex("kontoId");

                    b.ToTable("Kontakty");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Konto", b =>
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

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Umowa_sla", b =>
                {
                    b.Property<int>("umowa_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CzasReakcjiMin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CzasRozwiazaniaMin")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("kontoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("umowa_id");

                    b.HasIndex("kontoId");

                    b.ToTable("UmowySla");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Kontakt", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Konto", "Konto")
                        .WithMany()
                        .HasForeignKey("kontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Konto");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Umowa_sla", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Konto", "Konto")
                        .WithMany()
                        .HasForeignKey("kontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Konto");
                });
#pragma warning restore 612, 618
        }
    }
}
