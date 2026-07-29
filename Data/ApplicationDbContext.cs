using Microsoft.EntityFrameworkCore;
using LuxuryHotel.Models;

namespace LuxuryHotel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhachSan> KhachSans { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<DonDatPhong> DonDatPhongs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DichVuPhu> DichVuPhus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Cấu hình Precision/Scale cho các thuộc tính decimal
            modelBuilder.Entity<ChucVu>().Property(c => c.Luong).HasPrecision(18, 2);
            modelBuilder.Entity<Phong>().Property(p => p.Gia).HasPrecision(18, 2);
            modelBuilder.Entity<DichVuPhu>().Property(d => d.Gia).HasPrecision(18, 2);
            modelBuilder.Entity<DonDatPhong>().Property(d => d.TongTien).HasPrecision(18, 2);
            modelBuilder.Entity<HoaDon>().Property(h => h.TongTienHD).HasPrecision(18, 2);

            modelBuilder.Entity<BinhLuan>()
                .HasOne(b => b.KhachSan)
                .WithMany()
                .HasForeignKey(b => b.MaKS)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonDatPhong>()
                .HasOne(d => d.KhachSan)
                .WithMany()
                .HasForeignKey(d => d.MaKS)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DichVuPhu>()
                .HasOne(d => d.KhachSan)
                .WithMany()
                .HasForeignKey(d => d.MaKS)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HoaDons)
                .HasForeignKey(h => h.MaKH)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Seed Dữ Liệu
            SeedData.Seed(modelBuilder);
        }
    }
}