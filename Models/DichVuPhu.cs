using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class DichVuPhu
    {
        [Key]
        [StringLength(10)]
        public string MaDVP { get; set; } = null!;

        [StringLength(100)]
        public string TenDVP { get; set; } = null!;

        public decimal Gia { get; set; }

        public string DescriptionDVP { get; set; } = null!;

        [StringLength(30)]
        public string TrangThai { get; set; } = null!; // "Hoạt Động", "Ngưng Hoạt Động"

        [StringLength(10)]
        public string MaPhong { get; set; } = null!;
        [ForeignKey("MaPhong")]
        public Phong? Phong { get; set; }

        [StringLength(10)]
        public string MaKS { get; set; } = null!;
        [ForeignKey("MaKS")]
        public KhachSan? KhachSan { get; set; }
    }
}