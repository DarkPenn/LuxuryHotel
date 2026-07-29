using LuxuryHotel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxuryHotel.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? city)
        {
            var query = _context.KhachSans
                .Include(k => k.Phongs)
                .AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                // Sửa thành .DiaDiem cho đúng với Model KhachSan
                query = query.Where(k => k.DiaDiem.Contains(city));
            }

            var khachSans = await query.ToListAsync();

            ViewBag.SelectedCity = city ?? "Tất cả khu vực";

            return View(khachSans);
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Search(string? location)
        {
            ViewBag.Location = location;

            return View();
        }
    }
}