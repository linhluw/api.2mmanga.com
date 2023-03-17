using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface IChiTietHoaDonBanService
    {
        List<ChiTietHoaDonBan> GetAll();

        ChiTietHoaDonBan GetById(string MaHoaDon);

        Task<ChiTietHoaDonBan> Add(ChiTietHoaDonBan item);

        bool Delete(string MaHoaDon);

        bool Update(ChiTietHoaDonBan item);
    }
}