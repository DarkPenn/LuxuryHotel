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

        // Action Tìm kiếm & Lọc Khách Sạn (Hiển thị giao diện theo Hình 2)
        public async Task<IActionResult> RoomSearch(
            string? location,
            DateTime? checkIn,
            DateTime? checkOut,
            bool wifiFree = false,
            bool giaRe = false,
            bool danhGiaCao = false,
            bool anSang = false)
        {

            if (checkIn.HasValue && checkOut.HasValue && checkIn > checkOut)
            {
                if (checkIn.Value >= checkOut.Value)
                {
                    ViewBag.DateError = "Ngày check-in phải trước ngày check-out.";
                    return View("Index");
                }    
               
            }

            var query = _context.KhachSans
                .Include(k => k.Phongs)
                .AsQueryable();

            // 1. Lọc theo địa điểm hoặc tên khách sạn
            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(k => k.DiaDiem.Contains(location) || k.TenKS.Contains(location));
            }

            var resultList = await query.ToListAsync();

            // 2. Bộ lọc phụ (Giá rẻ)
            if (giaRe)
            {
                resultList = resultList.OrderBy(k => k.Phongs != null && k.Phongs.Any() ? k.Phongs.Min(p => p.Gia) : 0).ToList();
            }



            // Truyền thông số sang View
            ViewBag.Location = string.IsNullOrWhiteSpace(location) ? "Tất cả địa điểm" : location;
            ViewBag.CheckIn = checkIn?.ToString("yyyy-MM-dd");
            ViewBag.CheckOut = checkOut?.ToString("yyyy-MM-dd");
            ViewBag.WifiFree = wifiFree;
            ViewBag.GiaRe = giaRe;
            ViewBag.DanhGiaCao = danhGiaCao;
            ViewBag.AnSang = anSang;

            return View(resultList);
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
                .ThenInclude(p => p.DonDatPhongs)
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