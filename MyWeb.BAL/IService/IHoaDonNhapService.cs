using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface IHoaDonNhapService
    {
        List<HoaDonNhap> GetAll();

        HoaDonNhap GetById(string MaHoaDon);

        Task<HoaDonNhap> Add(HoaDonNhap item);

        bool Delete(string MaHoaDon);

        bool Update(HoaDonNhap item);
    }
}