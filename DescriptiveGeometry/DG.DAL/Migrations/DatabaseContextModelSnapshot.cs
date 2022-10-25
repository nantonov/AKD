﻿// <auto-generated />
using System;
using DG.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DG.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DG.DAL.Entities.DrawingDescriptionRow", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionPhotoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrawingId")
                        .HasColumnType("int");

                    b.Property<string>("Points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrawingDescription");
                });

            modelBuilder.Entity("DG.DAL.Entities.DrawingRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DownLoadCount")
                        .HasColumnType("int");

                    b.Property<string>("DrawingPhotoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drawings");
                });

            modelBuilder.Entity("DG.DAL.Entities.DrawingDescriptionRow", b =>
                {
                    b.HasOne("DG.DAL.Entities.DrawingRow", "Drawing")
                        .WithOne("Description")
                        .HasForeignKey("DG.DAL.Entities.DrawingDescriptionRow", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drawing");
                });

            modelBuilder.Entity("DG.DAL.Entities.DrawingRow", b =>
                {
                    b.Navigation("Description");
                });
#pragma warning restore 612, 618
        }
    }
}
