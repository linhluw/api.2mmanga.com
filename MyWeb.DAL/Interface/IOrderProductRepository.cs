using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.DAL.Interface
{
    public interface IOrderProductRepository : IRepository<OrderProduct>
    {
        List<OrderProduct> GetOrderProductByOrderId(string OrderId);
    }
}