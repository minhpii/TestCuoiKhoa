using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chuas",
                columns: table => new
                {
                    ChuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapNhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenChua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruTri = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuas", x => x.ChuaId);
                });

            migrationBuilder.CreateTable(
                name: "DaoTrangs",
                columns: table => new
                {
                    DaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaKetThuc = table.Column<bool>(type: "bit", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiToChuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoThanhVienThamGia = table.Column<int>(type: "int", nullable: true),
                    ThoiGianToChuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTruTri = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTrangs", x => x.DaoTrangId);
                });

            migrationBuilder.CreateTable(
                name: "KieuThanhViens",
                columns: table => new
                {
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuThanhViens", x => x.KieuThanhVienId);
                });

            migrationBuilder.CreateTable(
                name: "PhatTus",
                columns: table => new
                {
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhChup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaHoanTuc = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayHoanTuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXuatGia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhapDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    MaXacThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuaId = table.Column<int>(type: "int", nullable: true),
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTus", x => x.PhatTuId);
                    table.ForeignKey(
                        name: "FK_PhatTus_Chuas_ChuaId",
                        column: x => x.ChuaId,
                        principalTable: "Chuas",
                        principalColumn: "ChuaId");
                    table.ForeignKey(
                        name: "FK_PhatTus_KieuThanhViens_KieuThanhVienId",
                        column: x => x.KieuThanhVienId,
                        principalTable: "KieuThanhViens",
                        principalColumn: "KieuThanhVienId");
                });

            migrationBuilder.CreateTable(
                name: "DonDangKys",
                columns: table => new
                {
                    DonDangKyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayGuiDon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXuLy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXuLy = table.Column<int>(type: "int", nullable: true),
                    TrangThaiDon = table.Column<int>(type: "int", nullable: true),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDangKys", x => x.DonDangKyId);
                    table.ForeignKey(
                        name: "FK_DonDangKys_DaoTrangs_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrangs",
                        principalColumn: "DaoTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDangKys_PhatTus_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTus",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhatTuDaoTrangs",
                columns: table => new
                {
                    PhanTuDaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaThamGia = table.Column<bool>(type: "bit", nullable: true),
                    LyDoKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhanTuId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTuDaoTrangs", x => x.PhanTuDaoTrangId);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrangs_DaoTrangs_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrangs",
                        principalColumn: "DaoTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrangs_PhatTus_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTus",
                        principalColumn: "PhatTuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKys_DaoTrangId",
                table: "DonDangKys",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKys_PhatTuId",
                table: "DonDangKys",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrangs_DaoTrangId",
                table: "PhatTuDaoTrangs",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrangs_PhatTuId",
                table: "PhatTuDaoTrangs",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTus_ChuaId",
                table: "PhatTus",
                column: "ChuaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTus_KieuThanhVienId",
                table: "PhatTus",
                column: "KieuThanhVienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonDangKys");

            migrationBuilder.DropTable(
                name: "PhatTuDaoTrangs");

            migrationBuilder.DropTable(
                name: "DaoTrangs");

            migrationBuilder.DropTable(
                name: "PhatTus");

            migrationBuilder.DropTable(
                name: "Chuas");

            migrationBuilder.DropTable(
                name: "KieuThanhViens");
        }
    }
}
