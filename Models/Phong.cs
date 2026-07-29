using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class Phong
    {
        [Key]
        [StringLength(10)]
        public string MaPhong { get; set; } = null!;

        [StringLength(50)]
        public string LoaiPhong { get; set; } = null!;

        public decimal Gia { get; set; }

        public byte SoNguoi { get; set; }

        public string DescriptionPhong { get; set; } = null!;

        [StringLength(20)]
        public string TrangThaiPhong { get; set; } = null!; // "Trống", "Có Khách", "Thiết Hại"

        [StringLength(10)]
        public string MaKS { get; set; } = null!;
        [ForeignKey("MaKS")]
        public KhachSan? KhachSan { get; set; }

        public ICollection<BinhLuan>? BinhLuans { get; set; }
        public ICollection<DichVuPhu>? DichVuPhus { get; set; }
        public ICollection<DonDatPhong>? DonDatPhongs { get; set; }
    }
}