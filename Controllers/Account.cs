using Microsoft.AspNetCore.Mvc;

namespace LuxuryHotel.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
