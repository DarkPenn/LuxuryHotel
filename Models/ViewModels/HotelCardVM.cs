namespace LuxuryHotel.Models.ViewModels
{
    public class HotelCardVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Star { get; set; }
        public double Score { get; set; }
        public string Review { get; set; }
        public string Price { get; set; }
        public bool IncludeTax { get; set; }
    }
}