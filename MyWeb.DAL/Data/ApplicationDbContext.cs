using Microsoft.EntityFrameworkCore;
using MyWeb.DAL.Models;

namespace MyWeb.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<SanPham> SanPham { get; set; }

        public DbSet<NhaXuatBan> NhaXuatBan { get; set; }

        public DbSet<HoaDonBan> HoaDonBan { get; set; }

        public DbSet<HoaDonNhap> HoaDonNhap { get; set; }

        public DbSet<DanhMuc> DanhMuc { get; set; }

        public DbSet<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }

        public DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
    }
}