using LuxuryHotel.Data;
using LuxuryHotel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxuryHotel.ViewComponents
{
    public class HotelListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public HotelListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var hotels = _context.KhachSans
                .Include(x => x.Phongs)
                .ToList()
                .Select(h => new HotelCardVM
                {
                    // LẤY TỪ DATABASE 

                    Name = h.TenKS,

                    Address = h.DiaDiem,

                    Description = h.DescriptionKS,

                    Price = h.Phongs.Any()
                        ? h.Phongs.Min(p => p.Gia).ToString("N0") + " VND"
                        : "Liên hệ",

                    // ===== CHƯA CÓ TRONG DATABASE =====

                    Image = h.MaKS switch
                    {
                        "KS01" => "/images/hotel1.jpg",
                        "KS02" => "/images/hotel2.jpg",
                        "KS03" => "/images/hotel3.jpg",
                        "KS04" => "/images/hotel4.jpg",
                        _ => "/images/no-image.png"
                    },

                    Star = 5,

                    Score = h.MaKS switch
                    {
                        "KS01" => 8.9,
                        "KS02" => 8.6,
                        "KS03" => 9.1,
                        "KS04" => 8.4,
                        _ => 8.0
                    },

                    Review = h.MaKS switch
                    {
                        "KS01" => "3684 Đánh giá",
                        "KS02" => "1850 Đánh giá",
                        "KS03" => "920 Đánh giá",
                        "KS04" => "1120 Đánh giá",
                        _ => "0 Đánh giá"
                    },

                    IncludeTax = false
                })
                .ToList();

            return View(hotels);
        }
    }
}