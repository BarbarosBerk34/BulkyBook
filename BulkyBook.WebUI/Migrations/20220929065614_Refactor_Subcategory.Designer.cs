﻿// <auto-generated />
using System;
using BulkyBook.WebUI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyBook.WebUI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220929065614_Refactor_Subcategory")]
    partial class Refactor_Subcategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BulkyBook.WebUI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDateTime");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int")
                        .HasColumnName("DisplayOrder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2022, 9, 29, 9, 56, 14, 328, DateTimeKind.Local).AddTicks(7323),
                            DisplayOrder = 11,
                            Name = "Literature"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2022, 9, 29, 9, 56, 14, 328, DateTimeKind.Local).AddTicks(7335),
                            DisplayOrder = 22,
                            Name = "Preparation for Exams"
                        });
                });

            modelBuilder.Entity("BulkyBook.WebUI.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Story"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "TYT"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "DGS"
                        });
                });

            modelBuilder.Entity("BulkyBook.WebUI.Models.SubCategory", b =>
                {
                    b.HasOne("BulkyBook.WebUI.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BulkyBook.WebUI.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}