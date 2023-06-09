﻿// <auto-generated />
using BaoCaoBaiTapLonNhom02.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaoCaoBaiTapLonNhom02.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230403023502_Nhom")]
    partial class Nhom
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BaoCaoBaiTapLonNhom02.Models.Nhom", b =>
                {
                    b.Property<string>("MaNhom")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhom")
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhom");

                    b.ToTable("Nhom");
                });

            modelBuilder.Entity("BaoCaoBaiTapLonNhom02.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSV")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNhom")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSV")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("MaSV");

                    b.HasIndex("MaNhom");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("BaoCaoBaiTapLonNhom02.Models.SinhVien", b =>
                {
                    b.HasOne("BaoCaoBaiTapLonNhom02.Models.Nhom", "Nhom")
                        .WithMany()
                        .HasForeignKey("MaNhom");

                    b.Navigation("Nhom");
                });
#pragma warning restore 612, 618
        }
    }
}
