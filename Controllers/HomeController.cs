using LuxuryHotel.Data;
using LuxuryHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LuxuryHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Action lấy danh sách khách sạn
        [Route("Rooms")]
        public async Task<IActionResult> Rooms(string? city)
        {
            var query = _context.KhachSans
                .Include(k => k.Phongs)
                .AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                // Lọc theo thuộc tính DiaDiem của Model KhachSan
                query = query.Where(k => k.DiaDiem.Contains(city));
            }

            var khachSans = await query.ToListAsync();

            ViewBag.SelectedCity = city ?? "Tất cả khu vực";

            return View(khachSans);
        }

        // Action lấy thông tin chi tiết khách sạn và danh sách phòng tương ứng
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var khachSan = await _context.KhachSans
                .Include(k => k.Phongs)
                .FirstOrDefaultAsync(k => k.MaKS == id);

            if (khachSan == null)
            {
                return NotFound();
            }

            return View(khachSan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}