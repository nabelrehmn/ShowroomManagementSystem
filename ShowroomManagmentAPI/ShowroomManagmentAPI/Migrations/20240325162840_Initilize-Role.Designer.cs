﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowroomManagmentAPI.Data;

#nullable disable

namespace ShowroomManagmentAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240325162840_Initilize-Role")]
    partial class InitilizeRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShowroomManagmentAPI.Data.Department", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ShowroomManagmentAPI.Data.Role", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkId");

                    b.ToTable("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
