using MyWeb.BAL.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IRepository<User> _repo;

        public UserService(IRepository<User> repo, ICacheData memoryCache) : base(repo, memoryCache)
        {
            _repo = repo;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isCreate"></param>
        /// <returns></returns>
        public override bool CreateOrUpdate(User item, bool isCreate = true)
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
                    var data = GetById(item.PK_UserId);
                    if (data != null)
                    {
                        data.Name = item.Name;
                        data.Password = item.Password;
                        data.Phone = item.Phone;
                        data.Address = item.Address;
                        data.IsActive = item.IsActive;
                        data.PermissionId = item.PermissionId;
                    }
                }
            }
            return result;
        }
    }
}