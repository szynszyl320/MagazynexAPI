﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Magazynex_New.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("API_Magazynex_New.Encje.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numer_Telefonu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Firmas");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Magazyn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nazwa")
                        .HasColumnType("longtext");

                    b.Property<string>("Przechowywane_Materialy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lokalizacja")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Magazyns");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imie")
                        .HasColumnType("longtext");

                    b.Property<int?>("MagazynId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("longtext");

                    b.Property<string>("Numer_Telefonu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Stanowisko")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MagazynId");

                    b.ToTable("Pracowniks");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Towar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<float?>("Cena_Netto_Za_Sztuke")
                        .HasColumnType("float");

                    b.Property<int?>("FirmaId")
                        .HasColumnType("int");

                    b.Property<int?>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("Klasa_Towaru")
                        .HasColumnType("int");

                    b.Property<int?>("MagazynId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa_Produktu")
                        .HasColumnType("longtext");

                    b.Property<string>("Opis_Produktu")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("FirmaId");

                    b.HasIndex("MagazynId");

                    b.ToTable("Towars");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Pracownik", b =>
                {
                    b.HasOne("API_Magazynex_New.Encje.Magazyn", "Magazyn")
                        .WithMany("Pracownicy")
                        .HasForeignKey("MagazynId");

                    b.Navigation("Magazyn");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Towar", b =>
                {
                    b.HasOne("API_Magazynex_New.Encje.Firma", "Firma")
                        .WithMany("Towars")
                        .HasForeignKey("FirmaId");

                    b.HasOne("API_Magazynex_New.Encje.Magazyn", "Magazyn")
                        .WithMany("Towary")
                        .HasForeignKey("MagazynId");

                    b.Navigation("Firma");

                    b.Navigation("Magazyn");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Firma", b =>
                {
                    b.Navigation("Towars");
                });

            modelBuilder.Entity("API_Magazynex_New.Encje.Magazyn", b =>
                {
                    b.Navigation("Pracownicy");

                    b.Navigation("Towary");
                });
#pragma warning restore 612, 618
        }
    }
}
