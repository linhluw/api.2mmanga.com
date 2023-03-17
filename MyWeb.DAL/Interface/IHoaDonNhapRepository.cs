using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface IHoaDonNhapRepository : IRepository<HoaDonNhap>
    {
        HoaDonNhap GetById(string MaHoaDon);
    }
}