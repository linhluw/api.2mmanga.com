using MyWeb.BAL.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Linq;

namespace MyWeb.BAL.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IRepository<Category> _repo;

        public CategoryService(IRepository<Category> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override Category GetById(string Id)
        {
            return GetAll()?.FirstOrDefault(x => x.PK_CategoryId == Id);
        }

        public Category GetByName(string name)
        {
            return GetAll()?.FirstOrDefault(x => x.Name == name);
        }
    }
}