using System.ComponentModel.DataAnnotations;

namespace LuxuryHotel.Models
{
    public class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaKH { get; set; } = null!;

        [StringLength(50)]
        public string TenKH { get; set; } = null!;

        [StringLength(12)]
        public string CCCD_CMND_KH { get; set; } = null!;

        public ICollection<DonDatPhong>? DonDatPhongs { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}