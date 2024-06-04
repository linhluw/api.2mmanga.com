using MyWeb.BAL.Cache;
using MyWeb.BAL.ViewModels.Response;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWeb.BAL.Service
{
    public class CartService : BaseService<Cart>, ICartService
    {
        private readonly ICartRepository _repo;

        public CartService(ICartRepository repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lấy danh sách
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Cart> GetCartByUserId(string userid)
        {
            var response = new List<Cart>();
            var lst = _repo.GetCartByUserId(userid);
            if (lst != null && lst.Count > 0)
            {
                response = lst;
            }
            return response;
        }
    }
}