using MyWeb.BAL.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Linq;

namespace MyWeb.BAL.Service
{
    public class PublishedService : BaseService<Published>, IPublishedService
    {
        private readonly IRepository<Published> _repo;

        public PublishedService(IRepository<Published> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            _repo = repo;
        }

        public override Published GetById(string Id)
        {
            return GetAll()?.FirstOrDefault(x => x.PK_PublishedId == Id);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isCreate"></param>
        /// <returns></returns>
        public override bool CreateOrUpdate(Published item, bool isCreate = true)
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
                    var data = GetById(item.PK_PublishedId);
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