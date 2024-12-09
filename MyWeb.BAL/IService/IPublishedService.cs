using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public interface IPublishedService : IBaseService<Published>
    {
        Published GetByName(string name);
    }
}