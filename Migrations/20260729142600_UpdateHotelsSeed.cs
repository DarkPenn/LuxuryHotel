using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuxuryHotel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KhachSans",
                columns: new[] { "MaKS", "DescriptionKS", "DiaDiem", "TenKS" },
                values: new object[,]
                {
                    { "KS05", "Khu nghỉ dưỡng cao cấp với hồ bơi vô cực nhìn ra Bãi Sau.", "Vũng Tàu", "LX Luxury Resort Vũng Tàu" },
                    { "KS06", "Tọa lạc tại vị trí vàng đường Trần Phú, tầm nhìn toàn cảnh vịnh.", "Nha Trang", "LX Beachfront Hotel Nha Trang" },
                    { "KS07", "Nằm bên bờ sông Hàn thơ mộng, gần cầu Tình Yêu và Cầu Rồng.", "Đà Nẵng", "LX Riverside Hotel Đà Nẵng" },
                    { "KS08", "Khách sạn căn hộ cao cấp ngay trung tâm Quận 1 sầm uất.", "Hồ Chí Minh", "LX Suite Hotel Hồ Chí Minh" }
                });

            migrationBuilder.UpdateData(
                table: "Phongs",
                keyColumn: "MaPhong",
                keyValue: "P301",
                column: "Gia",
                value: 2100000m);

            migrationBuilder.InsertData(
                table: "Phongs",
                columns: new[] { "MaPhong", "DescriptionPhong", "Gia", "LoaiPhong", "MaKS", "SoNguoi", "TrangThaiPhong" },
                values: new object[,]
                {
                    { "P501", "Villa cao cấp view biển Bãi Sau", 1450000m, "Villa Ocean View", "KS05", (byte)4, "Trống" },
                    { "P601", "Phòng view biển ngắm trọn Vịnh Nha Trang", 1850000m, "Deluxe Sea View", "KS06", (byte)2, "Trống" },
                    { "P701", "Phòng view sông Hàn và Cầu Rồng", 1650000m, "Riverfront Suite", "KS07", (byte)2, "Trống" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KhachSans",
                keyColumn: "MaKS",
                keyValue: "KS08");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "MaPhong",
                keyValue: "P501");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "MaPhong",
                keyValue: "P601");

            migrationBuilder.DeleteData(
                table: "Phongs",
                keyColumn: "MaPhong",
                keyValue: "P701");

            migrationBuilder.DeleteData(
                table: "KhachSans",
                keyColumn: "MaKS",
                keyValue: "KS05");

            migrationBuilder.DeleteData(
                table: "KhachSans",
                keyColumn: "MaKS",
                keyValue: "KS06");

            migrationBuilder.DeleteData(
                table: "KhachSans",
                keyColumn: "MaKS",
                keyValue: "KS07");

            migrationBuilder.UpdateData(
                table: "Phongs",
                keyColumn: "MaPhong",
                keyValue: "P301",
                column: "Gia",
                value: 5000000m);
        }
    }
}
