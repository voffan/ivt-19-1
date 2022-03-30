﻿// <auto-generated />
using System;
using Autoreport.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Autoreport.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Autoreport.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Autoreport.Models.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("DepositType")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Autoreport.Models.Disk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<int>("Current_count")
                        .HasColumnType("int");

                    b.Property<int>("General_count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Article")
                        .IsUnique();

                    b.ToTable("Disks");
                });

            modelBuilder.Entity("Autoreport.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("FilmCountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FilmCountryId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Autoreport.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Autoreport.Models.HashSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HashSize")
                        .HasColumnType("int");

                    b.Property<int>("Iterations")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("longtext");

                    b.Property<int>("SaltSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HashSettings");
                });

            modelBuilder.Entity("Autoreport.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<int>("OrderClientId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDepositId")
                        .HasColumnType("int");

                    b.Property<int>("OrderEmployeerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Order_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Return_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderClientId");

                    b.HasIndex("OrderDepositId");

                    b.HasIndex("OrderEmployeerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Autoreport.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Middle_name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("DiskFilm", b =>
                {
                    b.Property<int>("DisksId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("DisksId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("DiskFilm");
                });

            modelBuilder.Entity("DiskOrder", b =>
                {
                    b.Property<int>("DisksId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("DisksId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("DiskOrder");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("FilmGenre");
                });

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.Property<int>("FilmDirectorsId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("FilmDirectorsId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("FilmPerson");
                });

            modelBuilder.Entity("Autoreport.Models.Client", b =>
                {
                    b.HasBaseType("Autoreport.Models.Person");

                    b.Property<int>("Debt_count")
                        .HasColumnType("int");

                    b.Property<int>("Order_count")
                        .HasColumnType("int");

                    b.Property<string>("Phone_number1")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Phone_number2")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Autoreport.Models.Employee", b =>
                {
                    b.HasBaseType("Autoreport.Models.Person");

                    b.Property<int>("EmplPosition")
                        .HasColumnType("int");

                    b.Property<int>("EmplStatus")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Passport_number")
                        .HasColumnType("int");

                    b.Property<int>("Passport_serial")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Autoreport.Models.Deposit", b =>
                {
                    b.HasOne("Autoreport.Models.Client", "Owner")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Autoreport.Models.Film", b =>
                {
                    b.HasOne("Autoreport.Models.Country", "FilmCountry")
                        .WithMany("Films")
                        .HasForeignKey("FilmCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmCountry");
                });

            modelBuilder.Entity("Autoreport.Models.Order", b =>
                {
                    b.HasOne("Autoreport.Models.Client", "OrderClient")
                        .WithMany("Orders")
                        .HasForeignKey("OrderClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoreport.Models.Deposit", "OrderDeposit")
                        .WithMany()
                        .HasForeignKey("OrderDepositId");

                    b.HasOne("Autoreport.Models.Employee", "OrderEmployeer")
                        .WithMany("Orders")
                        .HasForeignKey("OrderEmployeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderClient");

                    b.Navigation("OrderDeposit");

                    b.Navigation("OrderEmployeer");
                });

            modelBuilder.Entity("DiskFilm", b =>
                {
                    b.HasOne("Autoreport.Models.Disk", null)
                        .WithMany()
                        .HasForeignKey("DisksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoreport.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiskOrder", b =>
                {
                    b.HasOne("Autoreport.Models.Disk", null)
                        .WithMany()
                        .HasForeignKey("DisksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoreport.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.HasOne("Autoreport.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoreport.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.HasOne("Autoreport.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("FilmDirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoreport.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Autoreport.Models.Country", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Autoreport.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Autoreport.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
