using LuxuryHotel.Data;
using LuxuryHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxuryHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password, string? returnUrl = null)
        {
            var user = _context.KhachHangs.FirstOrDefault(x => x.Email == Email
                                && x.Password == Password);

            if (user == null)
            {
                ViewBag.Email = Email;
                ViewBag.Error = "Sai email hoặc mật khẩu";
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            // Đồng bộ ghi Key Session là "MaKH"
            HttpContext.Session.SetString("MaKH", user.MaKH);
            HttpContext.Session.SetString("CustomerId", user.MaKH);
            HttpContext.Session.SetString("CustomerName", user.TenKH);
            HttpContext.Session.SetString("CustomerEmail", user.Email);

            // Nếu có returnUrl thì quay lại đúng trang đang đặt dở
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(KhachHang model, string ConfirmPassword)
        {
            // 1. Tự động sinh MaKH trước
            model.MaKH = "KH" + Guid.NewGuid().ToString("N")[..8];

            // 2. Bỏ qua kiểm tra lỗi Validation riêng của MaKH (vì ta đã tự sinh code ở trên)
            ModelState.Remove("MaKH");

            // 3. Kiểm tra ModelState sau khi đã tự sinh MaKH
            if (!ModelState.IsValid)
            {
                // Trả về lại View Register kèm model để hiển thị lỗi trên giao diện form thay vì Content thô
                return View(model);
            }

            if (model.Password != ConfirmPassword)
            {
                ModelState.AddModelError("", "Mật khẩu xác nhận không khớp.");
                return View(model);
            }

            if (_context.KhachHangs.Any(x => x.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email đã tồn tại.");
                return View(model);
            }

            if (_context.KhachHangs.Any(x => x.CCCD_CMND_KH == model.CCCD_CMND_KH))
            {
                ModelState.AddModelError("CCCD_CMND_KH", "CCCD/CMND đã được sử dụng.");
                return View(model);
            }

            try
            {
                _context.KhachHangs.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }

            // Ghi Session sau khi đăng ký thành công
            HttpContext.Session.SetString("MaKH", model.MaKH);
            HttpContext.Session.SetString("CustomerId", model.MaKH);
            HttpContext.Session.SetString("CustomerName", model.TenKH);
            HttpContext.Session.SetString("CustomerEmail", model.Email);

            return RedirectToAction("Index", "Home");
        }
    }
}