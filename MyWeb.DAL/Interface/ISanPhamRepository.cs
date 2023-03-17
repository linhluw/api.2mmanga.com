using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface ISanPhamRepository : IRepository<SanPham>
    {
        SanPham GetById(int Id);
    }
}