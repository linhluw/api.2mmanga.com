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
    }
}