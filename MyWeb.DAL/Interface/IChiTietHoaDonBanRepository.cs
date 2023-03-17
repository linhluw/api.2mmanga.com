using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface IChiTietHoaDonBanRepository : IRepository<ChiTietHoaDonBan>
    {
        ChiTietHoaDonBan GetById(string MaHoaDon);
    }
}