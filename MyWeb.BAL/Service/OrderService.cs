using MyWeb.BAL.Cache;
using MyWeb.BAL.ViewModels.Requests;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        //private readonly IRepository<Order> _repo;

        public OrderService(IRepository<Order> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            //_repo = repo;
        }
    }
}