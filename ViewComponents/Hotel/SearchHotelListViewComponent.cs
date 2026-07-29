using LuxuryHotel.Data;
using LuxuryHotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxuryHotel.ViewComponents.Hotel
{
    public class SearchHotelListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SearchHotelListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            string? location = ViewBag.Location;

            var query = _context.KhachSans
                                .Include(x => x.Phongs)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(x =>
                    x.DiaDiem.Contains(location) ||
                    x.TenKS.Contains(location));
            }

            var hotels = query
                .ToList()
                .Select(h => new HotelCardVM
                {
                    // Database
                    Name = h.TenKS,
                    Address = h.DiaDiem,
                    Description = h.DescriptionKS,

                    Price = h.Phongs.Any()
                        ? h.Phongs.Min(p => p.Gia).ToString("N0") + " VND"
                        : "Liên hệ",

                    // Hard code
                    Image = h.MaKS switch
                    {
                        "KS01" => "/images/hotel1.jpg",
                        "KS02" => "/images/hotel2.jpg",
                        "KS03" => "/images/hotel3.jpg",
                        "KS04" => "/images/hotel4.jpg",
                        _ => "/images/no-image.jpg"
                    },

                    Star = 5,

                    Score = h.MaKS switch
                    {
                        "KS01" => 9.1,
                        "KS02" => 8.8,
                        "KS03" => 8.5,
                        "KS04" => 9.3,
                        _ => 8.0
                    },

                    Review = h.MaKS switch
                    {
                        "KS01" => "1.248 đánh giá",
                        "KS02" => "2.150 đánh giá",
                        "KS03" => "846 đánh giá",
                        "KS04" => "3.521 đánh giá",
                        _ => "0 đánh giá"
                    },

                    IncludeTax = false
                })
                .ToList();

            return View(hotels);
        }
    }
}
