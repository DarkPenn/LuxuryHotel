using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class DonDatPhong
    {
        [Key]
        [StringLength(10)]
        public string MaD { get; set; } = null!;

        public decimal TongTien { get; set; }

        public DateTime NgayNhanPhong { get; set; }

        public DateTime NgayTraPhong { get; set; }

        [StringLength(30)]
        public string TrangThaiDonDatPhong { get; set; } = null!; // "Đã đặt trước", "Đã Hủy", "Đã hoàn thành"

        [StringLength(10)]
        public string MaKH { get; set; } = null!;
        [ForeignKey("MaKH")]
        public KhachHang? KhachHang { get; set; }

        [StringLength(10)]
        public string MaPhong { get; set; } = null!;
        [ForeignKey("MaPhong")]
        public Phong? Phong { get; set; }

        [StringLength(10)]
        public string MaKS { get; set; } = null!;
        [ForeignKey("MaKS")]
        public KhachSan? KhachSan { get; set; }

        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}