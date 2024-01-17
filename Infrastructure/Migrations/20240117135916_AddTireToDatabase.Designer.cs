﻿// <auto-generated />
using System;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SqlServer))]
    [Migration("20240117135916_AddTireToDatabase")]
    partial class AddTireToDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Brands.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BrandId");

                    b.HasIndex("BrandName")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Domain.Models.Gearboxes.Gearbox", b =>
                {
                    b.Property<Guid>("GearboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GearboxModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SixGears")
                        .HasColumnType("bit");

                    b.HasKey("GearboxId");

                    b.HasIndex("BrandId");

                    b.ToTable("GearBoxes");
                });

            modelBuilder.Entity("Domain.Models.Gearboxes.Gearbox", b =>
                {
                    b.HasOne("Domain.Models.Brands.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
