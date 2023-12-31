﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Entity;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(AppDbConText))]
    partial class AppDbConTextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test.Entity.Chua", b =>
                {
                    b.Property<int>("ChuaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChuaId"), 1L, 1);

                    b.Property<DateTime?>("CapNhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenChua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruTri")
                        .HasColumnType("int");

                    b.HasKey("ChuaId");

                    b.ToTable("Chuas");
                });

            modelBuilder.Entity("Test.Entity.DaoTrang", b =>
                {
                    b.Property<int>("DaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DaoTrangId"), 1L, 1);

                    b.Property<bool?>("DaKetThuc")
                        .HasColumnType("bit");

                    b.Property<int?>("NguoiTruTri")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiToChuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoThanhVienThamGia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ThoiGianToChuc")
                        .HasColumnType("datetime2");

                    b.HasKey("DaoTrangId");

                    b.ToTable("DaoTrangs");
                });

            modelBuilder.Entity("Test.Entity.DonDangKy", b =>
                {
                    b.Property<int>("DonDangKyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonDangKyId"), 1L, 1);

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayGuiDon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXuLy")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiXuLy")
                        .HasColumnType("int");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThaiDon")
                        .HasColumnType("int");

                    b.HasKey("DonDangKyId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("DonDangKys");
                });

            modelBuilder.Entity("Test.Entity.KieuThanhVien", b =>
                {
                    b.Property<int>("KieuThanhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KieuThanhVienId"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KieuThanhVienId");

                    b.ToTable("KieuThanhViens");
                });

            modelBuilder.Entity("Test.Entity.PhatTu", b =>
                {
                    b.Property<int>("PhatTuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhatTuId"), 1L, 1);

                    b.Property<string>("AnhChup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChuaId")
                        .HasColumnType("int");

                    b.Property<bool?>("DaHoanTuc")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("KieuThanhVienId")
                        .HasColumnType("int");

                    b.Property<string>("MaXacThuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayHoanTuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXuatGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhapDanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhatTuId");

                    b.HasIndex("ChuaId");

                    b.HasIndex("KieuThanhVienId");

                    b.ToTable("PhatTus");
                });

            modelBuilder.Entity("Test.Entity.PhatTuDaoTrang", b =>
                {
                    b.Property<int>("PhanTuDaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhanTuDaoTrangId"), 1L, 1);

                    b.Property<bool?>("DaThamGia")
                        .HasColumnType("bit");

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("LyDoKhongThamGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhanTuId")
                        .HasColumnType("int");

                    b.Property<int?>("PhatTuId")
                        .HasColumnType("int");

                    b.HasKey("PhanTuDaoTrangId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("PhatTuDaoTrangs");
                });

            modelBuilder.Entity("Test.Entity.DonDangKy", b =>
                {
                    b.HasOne("Test.Entity.DaoTrang", "DaoTrang")
                        .WithMany()
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Entity.PhatTu", "PhatTu")
                        .WithMany("DonDangKy")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("Test.Entity.PhatTu", b =>
                {
                    b.HasOne("Test.Entity.Chua", "Chua")
                        .WithMany("PhatTu")
                        .HasForeignKey("ChuaId");

                    b.HasOne("Test.Entity.KieuThanhVien", "KieuThanhVien")
                        .WithMany("PhatTu")
                        .HasForeignKey("KieuThanhVienId");

                    b.Navigation("Chua");

                    b.Navigation("KieuThanhVien");
                });

            modelBuilder.Entity("Test.Entity.PhatTuDaoTrang", b =>
                {
                    b.HasOne("Test.Entity.DaoTrang", "DaoTrang")
                        .WithMany()
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Entity.PhatTu", "PhatTu")
                        .WithMany("PhatTuDaoTrang")
                        .HasForeignKey("PhatTuId");

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("Test.Entity.Chua", b =>
                {
                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("Test.Entity.KieuThanhVien", b =>
                {
                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("Test.Entity.PhatTu", b =>
                {
                    b.Navigation("DonDangKy");

                    b.Navigation("PhatTuDaoTrang");
                });
#pragma warning restore 612, 618
        }
    }
}
