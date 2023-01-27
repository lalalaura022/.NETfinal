﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiectfinaal2.data;

namespace proiectfinaal2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230127121205_AddedAnimalMedicament")]
    partial class AddedAnimalMedicament
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proiectfinaal2.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("Numar")
                        .HasColumnType("int");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strada")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kg")
                        .HasColumnType("int");

                    b.Property<int>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.AnimalMedicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalMedicamente");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gramaj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medicamente");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Stapan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Stapani");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Address", b =>
                {
                    b.HasOne("proiectfinaal2.Entities.Animal", "Animal")
                        .WithOne("Address")
                        .HasForeignKey("proiectfinaal2.Entities.Address", "AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.AnimalMedicament", b =>
                {
                    b.HasOne("proiectfinaal2.Entities.Animal", "Animal")
                        .WithMany("AnimalMedicamente")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiectfinaal2.Entities.Medicament", "Medicament")
                        .WithMany("AnimalMedicamente")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Medicament");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Stapan", b =>
                {
                    b.HasOne("proiectfinaal2.Entities.Animal", "Animal")
                        .WithMany("Stapani")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Animal", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("AnimalMedicamente");

                    b.Navigation("Stapani");
                });

            modelBuilder.Entity("proiectfinaal2.Entities.Medicament", b =>
                {
                    b.Navigation("AnimalMedicamente");
                });
#pragma warning restore 612, 618
        }
    }
}