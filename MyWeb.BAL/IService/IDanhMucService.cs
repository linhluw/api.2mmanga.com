using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.BAL.Service
{
    public interface IDanhMucService
    {
        List<DanhMuc> GetAll();

        DanhMuc GetById(int Id);

        Task<DanhMuc> Add(DanhMuc item);

        bool Delete(int Id);

        bool Update(DanhMuc item);
    }
}