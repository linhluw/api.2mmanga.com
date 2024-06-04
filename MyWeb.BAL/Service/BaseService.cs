using Microsoft.Data.SqlClient.Server;
using MyWeb.BAL.Cache;
using MyWeb.COM.Cache;
using MyWeb.COM.Helper.Cache;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWeb.BAL.Service
{
    public abstract class BaseService<T>
    {
        private readonly IRepository<T> _repo;
        private readonly ICacheData _memoryCache;

        public BaseService(IRepository<T> repo, ICacheData memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Lấy tất cả
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            var data = new List<T>();

            string cache = ManagerCacheString.ConstructCacheKey(typeof(T).Name, CacheKey.CacheAll);

            var cacheData = _memoryCache.Get<List<T>>(cache);

            if (cacheData != null && cacheData.Count > 0)
            {
                data = cacheData;
            }
            else
            {
                data = _repo.GetAll().ToList();

                if (data != null && data.Count > 0)
                {
                    _memoryCache.Set(cache, data, CacheTime.Default);
                }
                else
                {
                    data = null;
                }
            }
            return data;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetById(string Id)
        {
            string cache = ManagerCacheString.ConstructCacheKey(typeof(T).Name, string.Format("{0}-{1}", CacheKey.CacheKeyId, Id));

            var cacheData = _memoryCache.Get<T>(cache);

            if (cacheData != null)
            {
                return cacheData;
            }
            else
            {
                var data = _repo.GetById(Id);
                if (data != null)
                {
                    _memoryCache.Set(cache, data, CacheTime.Default1Hours);
                }
                return data;
            }
        }

        //Add
        public virtual bool CreateOrUpdate(T item, bool isCreate = true)
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
                    RemoveCache();
                }
            }
            return result;
        }

        //Delete
        public virtual bool Delete(T item)
        {
            return _repo.Delete(item) ? true : false;
        }

        public void RemoveCache()
        {
            string cache = ManagerCacheString.ConstructCacheKey(typeof(T).Name, CacheKey.CacheAll);
            _memoryCache.Remove(cache);
        }
    }
}