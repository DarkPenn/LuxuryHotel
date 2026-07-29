using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHD { get; set; } = null!;

        public decimal TongTienHD { get; set; }

        public DateTime ThoiGianHD { get; set; }

        [StringLength(30)]
        public string TrangThaiHD { get; set; } = null!; // "Chưa Thanh Toán", "Đã Thanh Toán"

        [StringLength(10)]
        public string MaKH { get; set; } = null!;
        [ForeignKey("MaKH")]
        public KhachHang? KhachHang { get; set; }

        [StringLength(10)]
        public string MaD { get; set; } = null!;
        [ForeignKey("MaD")]
        public DonDatPhong? DonDatPhong { get; set; }
    }
}