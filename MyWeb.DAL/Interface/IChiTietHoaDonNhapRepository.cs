using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface IChiTietHoaDonNhapRepository : IRepository<ChiTietHoaDonNhap>
    {
        ChiTietHoaDonNhap GetById(string MaHoaDon);
    }
}