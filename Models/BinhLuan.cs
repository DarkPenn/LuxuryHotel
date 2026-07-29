using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxuryHotel.Models
{
    public class BinhLuan
    {
        [Key]
        [StringLength(10)]
        public string MaBL { get; set; } = null!;

        [StringLength(255)]
        public string NoiDung { get; set; } = null!;

        public DateTime ThoiGianDang { get; set; }

        public int LuotThich { get; set; } = 0;

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