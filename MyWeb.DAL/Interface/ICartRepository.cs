using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Numerics;

namespace MyWeb.DAL.Interface
{
    public interface ICartRepository : IRepository<Cart>
    {
        bool DeleteCart(string ProductId, string UserId);

        List<Cart> GetCartByUserId(string UserId);
    }
}