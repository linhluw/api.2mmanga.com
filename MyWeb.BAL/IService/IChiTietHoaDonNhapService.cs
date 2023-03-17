using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface IChiTietHoaDonNhapService
    {
        List<ChiTietHoaDonNhap> GetAll();

        ChiTietHoaDonNhap GetById(string MaHoaDon);

        Task<ChiTietHoaDonNhap> Add(ChiTietHoaDonNhap item);

        bool Delete(string MaHoaDon);

        bool Update(ChiTietHoaDonNhap item);
    }
}