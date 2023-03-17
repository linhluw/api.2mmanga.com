using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface ISanPhamService
    {
        List<SanPham> GetAll();

        SanPham GetById(int Id);

        Task<SanPham> Add(SanPham item);

        bool Delete(int Id);

        bool Update(SanPham item);
    }
}