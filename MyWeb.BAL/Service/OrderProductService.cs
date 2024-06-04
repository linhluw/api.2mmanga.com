using MyWeb.BAL.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public class OrderProductService : BaseService<OrderProduct>, IOrderProductService
    {
        //private readonly IRepository<OrderProduct> _repo;

        public OrderProductService(IRepository<OrderProduct> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            //_repo = repo;
        }
    }
}