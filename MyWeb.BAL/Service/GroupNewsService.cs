using MyWeb.BAL.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Linq;

namespace MyWeb.BAL.Service
{
    public class GroupNewsService : BaseService<GroupNews>, IGroupNewsService
    {
        //private readonly IRepository<GroupNews> _repo;

        public GroupNewsService(IRepository<GroupNews> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            //_repo = repo;
        }

        public override GroupNews GetById(string Id)
        {
            return GetAll()?.FirstOrDefault(x => x.PK_GroupNewsId == Id);
        }
    }
}