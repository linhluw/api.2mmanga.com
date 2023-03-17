using MyWeb.DAL.Models;

namespace MyWeb.DAL.Interface
{
    public interface INhaXuatBanRepository : IRepository<NhaXuatBan>
    {
        NhaXuatBan GetById(int Id);
    }
}