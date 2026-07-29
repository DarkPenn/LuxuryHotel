using LuxuryHotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LuxuryHotel.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Chức Vụ
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu { MaCV = "CV01", TenCV = "Quản lý", Luong = 15000000m },
                new ChucVu { MaCV = "CV02", TenCV = "Lễ tân", Luong = 8000000m },
                new ChucVu { MaCV = "CV03", TenCV = "Nhân viên Phục vụ", Luong = 6500000m }
            );

            // 2. Ban
            modelBuilder.Entity<Ban>().HasData(
                new Ban { MaBan = "BAN01", TenBan = "Ban Quản Lý" },
                new Ban { MaBan = "BAN02", TenBan = "Ban Lễ Tân" },
                new Ban { MaBan = "BAN03", TenBan = "Ban Dịch Vụ & Phòng" }
            );

            // 3. Nhân Viên
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien { MaNV = "NV01", TenNV = "Nguyễn Văn A", SDT = "0901234567", CCCD_CMND_NV = "012345678901", MaBan = "BAN01", MaCV = "CV01" },
                new NhanVien { MaNV = "NV02", TenNV = "Trần Thị B", SDT = "0912345678", CCCD_CMND_NV = "012345678902", MaBan = "BAN02", MaCV = "CV02" },
                new NhanVien { MaNV = "NV03", TenNV = "Lê Văn C", SDT = "0923456789", CCCD_CMND_NV = "012345678903", MaBan = "BAN03", MaCV = "CV03" }
            );

            // 4. Khách Hàng
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang { MaKH = "KH01", TenKH = "Phạm Minh D", CCCD_CMND_KH = "034567890123", Phone = "0788811035", Email = "customer@luxuryhotel.com", Password = "123456" },
                new KhachHang { MaKH = "KH02", TenKH = "Hoàng Thị E", CCCD_CMND_KH = "034567890124", Phone = "0788811039" },
                new KhachHang { MaKH = "KH03", TenKH = "Đỗ Văn F", CCCD_CMND_KH = "034567890125", Phone = "0788811042" }
            );

            // 5. Khách Sạn (Giữ 4 KS cũ + Thêm 4 KS mới thuộc đúng 4 khu vực)
            modelBuilder.Entity<KhachSan>().HasData(
                new KhachSan { MaKS = "KS01", TenKS = "LX Hotel Đà Nẵng", DiaDiem = "Đà Nẵng", DescriptionKS = "Khách sạn nghỉ dưỡng 5 sao sát biển Mỹ Khê." },
                new KhachSan { MaKS = "KS02", TenKS = "LX Hotel Vũng Tàu", DiaDiem = "Vũng Tàu", DescriptionKS = "Tận hưởng không khí biển tươi mát cùng dịch vụ cao cấp." },
                new KhachSan { MaKS = "KS03", TenKS = "LX Hotel Nha Trang", DiaDiem = "Nha Trang", DescriptionKS = "Khách sạn hiện đại nằm ngay trung tâm thành phố biển." },
                new KhachSan { MaKS = "KS04", TenKS = "LX Hotel Hồ Chí Minh", DiaDiem = "Hồ Chí Minh", DescriptionKS = "Sang trọng, đẳng cấp tọa lạc tại trung tâm Quận 1." },

                // 4 Khách sạn bổ sung thêm
                new KhachSan { MaKS = "KS05", TenKS = "LX Luxury Resort Vũng Tàu", DiaDiem = "Vũng Tàu", DescriptionKS = "Khu nghỉ dưỡng cao cấp với hồ bơi vô cực nhìn ra Bãi Sau." },
                new KhachSan { MaKS = "KS06", TenKS = "LX Beachfront Hotel Nha Trang", DiaDiem = "Nha Trang", DescriptionKS = "Tọa lạc tại vị trí vàng đường Trần Phú, tầm nhìn toàn cảnh vịnh." },
                new KhachSan { MaKS = "KS07", TenKS = "LX Riverside Hotel Đà Nẵng", DiaDiem = "Đà Nẵng", DescriptionKS = "Nằm bên bờ sông Hàn thơ mộng, gần cầu Tình Yêu và Cầu Rồng." },
                new KhachSan { MaKS = "KS08", TenKS = "LX Suite Hotel Hồ Chí Minh", DiaDiem = "Hồ Chí Minh", DescriptionKS = "Khách sạn căn hộ cao cấp ngay trung tâm Quận 1 sầm uất." }
            );

            // 6. Phòng
            modelBuilder.Entity<Phong>().HasData(
                new Phong { MaPhong = "P101", LoaiPhong = "Deluxe Ocean", Gia = 1200000m, SoNguoi = 2, DescriptionPhong = "Phòng hướng biển ban công rộng", TrangThaiPhong = "Trống", MaKS = "KS01" },
                new Phong { MaPhong = "P102", LoaiPhong = "Suite VIP", Gia = 2500000m, SoNguoi = 4, DescriptionPhong = "Phòng VIP đầy đủ tiện nghi xa hoa", TrangThaiPhong = "Có Khách", MaKS = "KS01" },
                new Phong { MaPhong = "P201", LoaiPhong = "Standard Double", Gia = 900000m, SoNguoi = 2, DescriptionPhong = "Phòng tiêu chuẩn ấm cúng", TrangThaiPhong = "Trống", MaKS = "KS02" },
                new Phong { MaPhong = "P301", LoaiPhong = "Presidential Suite", Gia = 2100000m, SoNguoi = 4, DescriptionPhong = "Phòng Tổng Thống đẳng cấp bậc nhất", TrangThaiPhong = "Thiết Hại", MaKS = "KS03" },

                // Phòng cho các khách sạn mới
                new Phong { MaPhong = "P501", LoaiPhong = "Villa Ocean View", Gia = 1450000m, SoNguoi = 4, DescriptionPhong = "Villa cao cấp view biển Bãi Sau", TrangThaiPhong = "Trống", MaKS = "KS05" },
                new Phong { MaPhong = "P601", LoaiPhong = "Deluxe Sea View", Gia = 1850000m, SoNguoi = 2, DescriptionPhong = "Phòng view biển ngắm trọn Vịnh Nha Trang", TrangThaiPhong = "Trống", MaKS = "KS06" },
                new Phong { MaPhong = "P701", LoaiPhong = "Riverfront Suite", Gia = 1650000m, SoNguoi = 2, DescriptionPhong = "Phòng view sông Hàn và Cầu Rồng", TrangThaiPhong = "Trống", MaKS = "KS07" }
                // KS04 & KS08 thuộc TP.HCM không thêm phòng để giá tự động hiển thị "Liên hệ"!
            );

            // 7. Bình Luận
            modelBuilder.Entity<BinhLuan>().HasData(
                new BinhLuan { MaBL = "BL01", NoiDung = "Phòng rất sạch đẹp, view biển tuyệt vời!", ThoiGianDang = new DateTime(2026, 3, 15, 10, 30, 0), LuotThich = 12, MaPhong = "P101", MaKS = "KS01" },
                new BinhLuan { MaBL = "BL02", NoiDung = "Dịch vụ phục vụ rất tận tình chu đáo.", ThoiGianDang = new DateTime(2026, 3, 20, 14, 15, 0), LuotThich = 5, MaPhong = "P102", MaKS = "KS01" }
            );

            // 8. Đơn Đặt Phòng
            modelBuilder.Entity<DonDatPhong>().HasData(
                new DonDatPhong { MaD = "D01", TongTien = 2400000m, NgayNhanPhong = new DateTime(2026, 4, 1, 14, 0, 0), NgayTraPhong = new DateTime(2026, 4, 3, 12, 0, 0), TrangThaiDonDatPhong = "Đã hoàn thành", MaKH = "KH01", MaPhong = "P101", MaKS = "KS01" },
                new DonDatPhong { MaD = "D02", TongTien = 2500000m, NgayNhanPhong = new DateTime(2026, 4, 10, 14, 0, 0), NgayTraPhong = new DateTime(2026, 4, 11, 12, 0, 0), TrangThaiDonDatPhong = "Đã đặt trước", MaKH = "KH02", MaPhong = "P102", MaKS = "KS01" }
            );

            // 9. Hóa Đơn
            modelBuilder.Entity<HoaDon>().HasData(
                new HoaDon { MaHD = "HD01", TongTienHD = 2400000m, ThoiGianHD = new DateTime(2026, 4, 3, 11, 45, 0), TrangThaiHD = "Đã Thanh Toán", MaKH = "KH01", MaD = "D01" },
                new HoaDon { MaHD = "HD02", TongTienHD = 2500000m, ThoiGianHD = new DateTime(2026, 4, 10, 14, 30, 0), TrangThaiHD = "Chưa Thanh Toán", MaKH = "KH02", MaD = "D02" }
            );

            // 10. Dịch Vụ Phụ
            modelBuilder.Entity<DichVuPhu>().HasData(
                new DichVuPhu { MaDVP = "DVP01", TenDVP = "Ăn Sáng Buffet", Gia = 150000m, DescriptionDVP = "Buffet sáng Á - Âu cao cấp", TrangThai = "Hoạt Động", MaPhong = "P101", MaKS = "KS01" },
                new DichVuPhu { MaDVP = "DVP02", TenDVP = "Dịch Vụ Spa & Massage", Gia = 500000m, DescriptionDVP = "Thư giãn 60 phút với thảo dược", TrangThai = "Hoạt Động", MaPhong = "P102", MaKS = "KS01" }
            );
        }
    }
}