using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface IHoaDonBanRepository : IRepository<HoaDonBan>
    {
        HoaDonBan GetById(string MaHoaDon);
    }
}