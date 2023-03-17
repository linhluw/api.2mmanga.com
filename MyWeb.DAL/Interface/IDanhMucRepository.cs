using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface IDanhMucRepository : IRepository<DanhMuc>
    {
        DanhMuc GetById(int Id);
    }
}