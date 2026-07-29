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

        [Required(ErrorMessage = "Vui lòng nhập CCCD/CMND")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "CCCD/CMND phải có từ 9 đến 12 số")]
        public string CCCD_CMND_KH { get; set; } = null!;

        public ICollection<DonDatPhong>? DonDatPhongs { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; }

        //Bổ sung
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0")]
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}