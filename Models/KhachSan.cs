using System.ComponentModel.DataAnnotations;

namespace LuxuryHotel.Models
{
    public class KhachSan
    {
        [Key]
        [StringLength(10)]
        public string MaKS { get; set; } = null!;

        [StringLength(100)]
        public string TenKS { get; set; } = null!;

        [StringLength(255)]
        public string DiaDiem { get; set; } = null!;

        public string DescriptionKS { get; set; } = null!;

        public ICollection<Phong>? Phongs { get; set; }
    }
}