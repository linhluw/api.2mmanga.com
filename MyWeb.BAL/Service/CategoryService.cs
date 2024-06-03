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

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isCreate"></param>
        /// <returns></returns>
        public override bool CreateOrUpdate(Category item, bool isCreate = true)
        {
            var result = _repo.CreateOrUpdate(item);
            if (result)
            {
                if (isCreate)
                {
                    var data = GetAll();
                    if (data != null && data.Count > 0)
                    {
                        data.Add(item);
                    }
                }
                else
                {
                    var data = GetById(item.PK_CategoryId);
                    if (data != null)
                    {
                        data.Name = item.Name;
                    }
                }
            }
            return result;
        }
    }
}