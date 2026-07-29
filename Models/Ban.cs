using System.ComponentModel.DataAnnotations;

namespace LuxuryHotel.Models
{
    public class Ban
    {
        [Key]
        [StringLength(10)]
        public string MaBan { get; set; } = null!;

        [StringLength(50)]
        public string TenBan { get; set; } = null!;

        public ICollection<NhanVien>? NhanViens { get; set; }
    }
}