﻿// <auto-generated />
using FFG.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FFG.Migrations.Sqlite.Migrations
{
    [DbContext(typeof(FFGDbContext))]
    [Migration("20240126201148_Create")]
    partial class Create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("FFG.Application.Models.CodeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER")
                        .HasColumnName("code");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_code_value");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_code_value_id");

                    b.ToTable("code_value", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
