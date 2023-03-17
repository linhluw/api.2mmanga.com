using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface IHoaDonBanService
    {
        List<HoaDonBan> GetAll();

        HoaDonBan GetById(string MaHoaDon);

        Task<HoaDonBan> Add(HoaDonBan item);

        bool Delete(string MaHoaDon);

        bool Update(HoaDonBan item);
    }
}