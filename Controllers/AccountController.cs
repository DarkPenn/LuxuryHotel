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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var user = _context.KhachHangs.FirstOrDefault(x => x.Email == Email
                                && x.Password == Password);

            if (user == null)
            {
                ViewBag.Email = Email;
                ViewBag.Error = "Sai email hoặc mật khẩu";
                return View();
            }

            HttpContext.Session.SetString("CustomerId", user.MaKH);
            HttpContext.Session.SetString("CustomerName", user.TenKH);
            HttpContext.Session.SetString("CustomerEmail", user.Email);

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
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors.Select(e => $"{x.Key}: {e.ErrorMessage}"))
                    .ToList();
                return Content(string.Join("\n", errors));
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

            int count = _context.KhachHangs.Count() + 1;
            model.MaKH = $"KH{count:000}";

            model.MaKH = "KH" + Guid.NewGuid().ToString("N")[..8];

            try
            {
                _context.KhachHangs.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }

            HttpContext.Session.SetString("CustomerId", model.MaKH);
            HttpContext.Session.SetString("CustomerName", model.TenKH);
            HttpContext.Session.SetString("CustomerEmail", model.Email);

            return RedirectToAction("Index", "Home");
        }
    }
}