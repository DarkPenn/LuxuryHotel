using LuxuryHotel.Data;
using Microsoft.AspNetCore.Mvc;

namespace LuxuryHotel.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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