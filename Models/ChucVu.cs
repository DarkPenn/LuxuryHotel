using System.ComponentModel.DataAnnotations;

namespace LuxuryHotel.Models
{
    public class ChucVu
    {
        [Key]
        [StringLength(10)]
        public string MaCV { get; set; } = null!;

        [StringLength(50)]
        public string TenCV { get; set; } = null!;

        public decimal Luong { get; set; }

        public ICollection<NhanVien>? NhanViens { get; set; }
    }
}