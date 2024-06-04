using MyWeb.DAL.Models;
using System.Collections.Generic;

namespace MyWeb.BAL.Service
{
    public interface ICartService : IBaseService<Cart>
    {
        List<Cart> GetCartByUserId(string userid);
    }
}