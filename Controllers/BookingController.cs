using LuxuryHotel.Data;
using LuxuryHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LuxuryHotel.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Booking/Create?maKS=KS01&maPhong=P101
        [HttpGet]
        public async Task<IActionResult> Create(string maKS, string maPhong)
        {
            // 1. Kiểm tra Đăng nhập qua Session
            string? maKH = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(maKH))
            {
                // Chưa đăng nhập -> Chuyển hướng sang trang Login
                return RedirectToAction("Login", "Account");
            }

            var khachHang = await _context.KhachHangs.FirstOrDefaultAsync(k => k.MaKH == maKH);
            var phong = await _context.Phongs.FirstOrDefaultAsync(p => p.MaPhong == maPhong);
            var khachSan = await _context.KhachSans.FirstOrDefaultAsync(k => k.MaKS == maKS);

            ViewBag.KhachHang = khachHang;
            ViewBag.Phong = phong;
            ViewBag.KhachSan = khachSan;

            return View();
        }

        // POST: /Booking/Create
        [HttpPost]
        public async Task<IActionResult> Create(string maKS, string maPhong, string ten, string ho, string email, string phone, string quocGia, string note)
        {
            string? maKH = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(maKH))
            {
                return RedirectToAction("Login", "Account");
            }

            // 2. Validate dữ liệu theo yêu cầu đề bài
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                ModelState.AddModelError("Email", "Email không hợp lệ (bắt buộc chứa ký tự @).");
            }

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^[0-9]{9,11}$"))
            {
                ModelState.AddModelError("Phone", "Số điện thoại chỉ bao gồm ký tự số và độ dài từ 9 đến 11 chữ số.");
            }

            var phong = await _context.Phongs.FirstOrDefaultAsync(p => p.MaPhong == maPhong);
            var khachSan = await _context.KhachSans.FirstOrDefaultAsync(k => k.MaKS == maKS);
            var khachHang = await _context.KhachHangs.FirstOrDefaultAsync(k => k.MaKH == maKH);

            if (!ModelState.IsValid)
            {
                ViewBag.KhachHang = khachHang;
                ViewBag.Phong = phong;
                ViewBag.KhachSan = khachSan;
                return View();
            }

            // 3. Tạo Mã đơn tự động (ví dụ: D03, D04...)
            int count = await _context.DonDatPhongs.CountAsync() + 1;
            string newMaD = "D" + count.ToString("D2");

            var donDatPhong = new DonDatPhong
            {
                MaD = newMaD,
                TongTien = phong != null ? phong.Gia : 0,
                NgayNhanPhong = DateTime.Now,
                NgayTraPhong = DateTime.Now.AddDays(1),
                TrangThaiDonDatPhong = "Đã đặt trước",
                MaKH = maKH,
                MaPhong = maPhong ?? "P101",
                MaKS = maKS ?? "KS01"
            };

            _context.DonDatPhongs.Add(donDatPhong);
            await _context.SaveChangesAsync();

            // Lưu thông báo thành công vào TempData để kích hoạt popup
            TempData["SuccessMessage"] = "Đặt phòng thành công! Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi.";

            // Chuyển hướng về trang chủ
            return RedirectToAction("Index", "Home");
        }
    }
}