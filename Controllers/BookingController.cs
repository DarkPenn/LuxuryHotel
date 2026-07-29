using Microsoft.AspNetCore.Mvc;

namespace LuxuryHotel.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
