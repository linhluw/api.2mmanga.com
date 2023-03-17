using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface INhaXuatBanService
    {
        List<NhaXuatBan> GetAll();

        NhaXuatBan GetById(int Id);

        Task<NhaXuatBan> Add(NhaXuatBan item);

        bool Delete(int Id);

        bool Update(NhaXuatBan item);
    }
}