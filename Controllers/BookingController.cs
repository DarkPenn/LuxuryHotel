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
            // 1. Kiểm tra Đăng nhập qua Session "MaKH"
            string? maKH = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(maKH))
            {
                // Tạo đường dẫn hiện tại kèm tham số để đăng nhập xong tự nhảy về lại đúng trang này
                string currentUrl = Url.Action("Create", "Booking", new { maKS = maKS, maPhong = maPhong }) ?? "/";
                return RedirectToAction("Login", "Account", new { returnUrl = currentUrl });
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

            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                ModelState.AddModelError("Email", "Email không hợp lệ (bắt buộc chứa ký tự @).");
            }

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^[0-9]{9,11}$"))
            {
                ModelState.AddModelError("Phone", "Số điện thoại chỉ bao gồm ký tự số và độ dài từ 9 đến 11 chữ số.");
            }

            var phong = await _context.Phongs.FirstOrDefaultAsync(p => p.MaPhong == maPhong && p.MaKS == maKS);
            var khachSan = await _context.KhachSans.FirstOrDefaultAsync(k => k.MaKS == maKS);
            var khachHang = await _context.KhachHangs.FirstOrDefaultAsync(k => k.MaKH == maKH);

            if (!ModelState.IsValid)
            {
                ViewBag.KhachHang = khachHang;
                ViewBag.Phong = phong;
                ViewBag.KhachSan = khachSan;
                return View();
            }

            // Tạo Mã đơn tự động
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
                MaPhong = maPhong,
                MaKS = maKS
            };

            _context.DonDatPhongs.Add(donDatPhong);

            // 👉 CHỈ CẬP NHẬT TRẠNG THÁI CHO CHÍNH PHÒNG ĐƯỢC CHỌN (maPhong)
            if (phong != null)
            {
                phong.TrangThaiPhong = "Có Khách"; // Đánh dấu phòng này đã được đặt
                _context.Phongs.Update(phong);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đặt phòng thành công! Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi.";

            return RedirectToAction("Index", "Home");
        }
    }
}