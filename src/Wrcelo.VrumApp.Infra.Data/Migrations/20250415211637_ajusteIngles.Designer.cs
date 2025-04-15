﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wrcelo.VrumApp.Infra.Data.Context;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20250415211637_ajusteIngles")]
    partial class ajusteIngles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.DeliveryDriver", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("DriverLicenseImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("DriverLicenseNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("DriverLicenseType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Guid");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("DriverLicenseNumber")
                        .IsUnique();

                    b.HasIndex("UserGuid")
                        .IsUnique();

                    b.ToTable("delivery_drivers", (string)null);
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.Motorcycle", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Guid");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("motorcycles", (string)null);
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.MotorcycleNotification", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("MotorcycleGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Guid");

                    b.ToTable("MotorcycleNotifications", (string)null);
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.Rental", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("DailyRate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("DeliveryDriverGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("MotorcycleGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("PlanDays")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Guid");

                    b.HasIndex("DeliveryDriverGuid");

                    b.HasIndex("MotorcycleGuid");

                    b.ToTable("rentals", (string)null);
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.Rental", b =>
                {
                    b.HasOne("Wrcelo.VrumApp.Domain.Entity.DeliveryDriver", "DeliveryDriver")
                        .WithMany("Rentals")
                        .HasForeignKey("DeliveryDriverGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Wrcelo.VrumApp.Domain.Entity.Motorcycle", "Motorcycle")
                        .WithMany("Rentals")
                        .HasForeignKey("MotorcycleGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DeliveryDriver");

                    b.Navigation("Motorcycle");
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.DeliveryDriver", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("Wrcelo.VrumApp.Domain.Entity.Motorcycle", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
