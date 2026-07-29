using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuxuryHotel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    MaBan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.MaBan);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    MaCV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenCV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Luong = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.MaCV);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD_CMND_KH = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KhachSans",
                columns: table => new
                {
                    MaKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenKS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescriptionKS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSans", x => x.MaKS);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CCCD_CMND_NV = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MaBan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaCV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_Bans_MaBan",
                        column: x => x.MaBan,
                        principalTable: "Bans",
                        principalColumn: "MaBan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_MaCV",
                        column: x => x.MaCV,
                        principalTable: "ChucVus",
                        principalColumn: "MaCV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LoaiPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SoNguoi = table.Column<byte>(type: "tinyint", nullable: false),
                    DescriptionPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiPhong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_Phongs_KhachSans_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhachSans",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuans",
                columns: table => new
                {
                    MaBL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ThoiGianDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LuotThich = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuans", x => x.MaBL);
                    table.ForeignKey(
                        name: "FK_BinhLuans_KhachSans_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhachSans",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BinhLuans_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DichVuPhus",
                columns: table => new
                {
                    MaDVP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenDVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DescriptionDVP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVuPhus", x => x.MaDVP);
                    table.ForeignKey(
                        name: "FK_DichVuPhus_KhachSans_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhachSans",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DichVuPhus_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDatPhongs",
                columns: table => new
                {
                    MaD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NgayNhanPhong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTraPhong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiDonDatPhong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatPhongs", x => x.MaD);
                    table.ForeignKey(
                        name: "FK_DonDatPhongs_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDatPhongs_KhachSans_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhachSans",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonDatPhongs_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TongTienHD = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThoiGianHD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiHD = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_DonDatPhongs_MaD",
                        column: x => x.MaD,
                        principalTable: "DonDatPhongs",
                        principalColumn: "MaD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bans",
                columns: new[] { "MaBan", "TenBan" },
                values: new object[,]
                {
                    { "BAN01", "Ban Quản Lý" },
                    { "BAN02", "Ban Lễ Tân" },
                    { "BAN03", "Ban Dịch Vụ & Phòng" }
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "MaCV", "Luong", "TenCV" },
                values: new object[,]
                {
                    { "CV01", 15000000m, "Quản lý" },
                    { "CV02", 8000000m, "Lễ tân" },
                    { "CV03", 6500000m, "Nhân viên Phục vụ" }
                });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "MaKH", "CCCD_CMND_KH", "TenKH" },
                values: new object[,]
                {
                    { "KH01", "034567890123", "Phạm Minh D" },
                    { "KH02", "034567890124", "Hoàng Thị E" },
                    { "KH03", "034567890125", "Đỗ Văn F" }
                });

            migrationBuilder.InsertData(
                table: "KhachSans",
                columns: new[] { "MaKS", "DescriptionKS", "DiaDiem", "TenKS" },
                values: new object[,]
                {
                    { "KS01", "Khách sạn nghỉ dưỡng 5 sao sát biển Mỹ Khê.", "Đà Nẵng", "LX Hotel Đà Nẵng" },
                    { "KS02", "Tận hưởng không khí biển tươi mát cùng dịch vụ cao cấp.", "Vũng Tàu", "LX Hotel Vũng Tàu" },
                    { "KS03", "Khách sạn hiện đại nằm ngay trung tâm thành phố biển.", "Nha Trang", "LX Hotel Nha Trang" },
                    { "KS04", "Sang trọng, đẳng cấp tọa lạc tại trung tâm Quận 1.", "Hồ Chí Minh", "LX Hotel Hồ Chí Minh" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "MaNV", "CCCD_CMND_NV", "MaBan", "MaCV", "SDT", "TenNV" },
                values: new object[,]
                {
                    { "NV01", "012345678901", "BAN01", "CV01", "0901234567", "Nguyễn Văn A" },
                    { "NV02", "012345678902", "BAN02", "CV02", "0912345678", "Trần Thị B" },
                    { "NV03", "012345678903", "BAN03", "CV03", "0923456789", "Lê Văn C" }
                });

            migrationBuilder.InsertData(
                table: "Phongs",
                columns: new[] { "MaPhong", "DescriptionPhong", "Gia", "LoaiPhong", "MaKS", "SoNguoi", "TrangThaiPhong" },
                values: new object[,]
                {
                    { "P101", "Phòng hướng biển ban công rộng", 1200000m, "Deluxe Ocean", "KS01", (byte)2, "Trống" },
                    { "P102", "Phòng VIP đầy đủ tiện nghi xa hoa", 2500000m, "Suite VIP", "KS01", (byte)4, "Có Khách" },
                    { "P201", "Phòng tiêu chuẩn ấm cúng", 900000m, "Standard Double", "KS02", (byte)2, "Trống" },
                    { "P301", "Phòng Tổng Thống đẳng cấp bậc nhất", 5000000m, "Presidential Suite", "KS03", (byte)4, "Thiết Hại" }
                });

            migrationBuilder.InsertData(
                table: "BinhLuans",
                columns: new[] { "MaBL", "LuotThich", "MaKS", "MaPhong", "NoiDung", "ThoiGianDang" },
                values: new object[,]
                {
                    { "BL01", 12, "KS01", "P101", "Phòng rất sạch đẹp, view biển tuyệt vời!", new DateTime(2026, 3, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { "BL02", 5, "KS01", "P102", "Dịch vụ phục vụ rất tận tình chu đáo.", new DateTime(2026, 3, 20, 14, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DichVuPhus",
                columns: new[] { "MaDVP", "DescriptionDVP", "Gia", "MaKS", "MaPhong", "TenDVP", "TrangThai" },
                values: new object[,]
                {
                    { "DVP01", "Buffet sáng Á - Âu cao cấp", 150000m, "KS01", "P101", "Ăn Sáng Buffet", "Hoạt Động" },
                    { "DVP02", "Thư giãn 60 phút với thảo dược", 500000m, "KS01", "P102", "Dịch Vụ Spa & Massage", "Hoạt Động" }
                });

            migrationBuilder.InsertData(
                table: "DonDatPhongs",
                columns: new[] { "MaD", "MaKH", "MaKS", "MaPhong", "NgayNhanPhong", "NgayTraPhong", "TongTien", "TrangThaiDonDatPhong" },
                values: new object[,]
                {
                    { "D01", "KH01", "KS01", "P101", new DateTime(2026, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 2400000m, "Đã hoàn thành" },
                    { "D02", "KH02", "KS01", "P102", new DateTime(2026, 4, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), 2500000m, "Đã đặt trước" }
                });

            migrationBuilder.InsertData(
                table: "HoaDons",
                columns: new[] { "MaHD", "MaD", "MaKH", "ThoiGianHD", "TongTienHD", "TrangThaiHD" },
                values: new object[,]
                {
                    { "HD01", "D01", "KH01", new DateTime(2026, 4, 3, 11, 45, 0, 0, DateTimeKind.Unspecified), 2400000m, "Đã Thanh Toán" },
                    { "HD02", "D02", "KH02", new DateTime(2026, 4, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 2500000m, "Chưa Thanh Toán" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuans_MaKS",
                table: "BinhLuans",
                column: "MaKS");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuans_MaPhong",
                table: "BinhLuans",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DichVuPhus_MaKS",
                table: "DichVuPhus",
                column: "MaKS");

            migrationBuilder.CreateIndex(
                name: "IX_DichVuPhus_MaPhong",
                table: "DichVuPhus",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatPhongs_MaKH",
                table: "DonDatPhongs",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatPhongs_MaKS",
                table: "DonDatPhongs",
                column: "MaKS");

            migrationBuilder.CreateIndex(
                name: "IX_DonDatPhongs_MaPhong",
                table: "DonDatPhongs",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaD",
                table: "HoaDons",
                column: "MaD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaKH",
                table: "HoaDons",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaBan",
                table: "NhanViens",
                column: "MaBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaCV",
                table: "NhanViens",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_MaKS",
                table: "Phongs",
                column: "MaKS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuans");

            migrationBuilder.DropTable(
                name: "DichVuPhus");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "DonDatPhongs");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "Phongs");

            migrationBuilder.DropTable(
                name: "KhachSans");
        }
    }
}
