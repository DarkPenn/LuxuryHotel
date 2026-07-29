using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; } = null!;

        [StringLength(50)]
        public string TenNV { get; set; } = null!;

        [StringLength(10)]
        public string SDT { get; set; } = null!;

        [StringLength(12)]
        public string CCCD_CMND_NV { get; set; } = null!;

        [StringLength(10)]
        public string MaBan { get; set; } = null!;
        [ForeignKey("MaBan")]
        public Ban? Ban { get; set; }

        [StringLength(10)]
        public string MaCV { get; set; } = null!;
        [ForeignKey("MaCV")]
        public ChucVu? ChucVu { get; set; }
    }
}