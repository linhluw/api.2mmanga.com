using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Numerics;

namespace MyWeb.DAL.Interface
{
    public interface ICartRepository : IRepository<Cart>
    {
        List<Cart> GetCartByUserId(string UserId);
    }
}