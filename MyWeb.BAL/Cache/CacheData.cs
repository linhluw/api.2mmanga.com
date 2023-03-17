using Microsoft.Extensions.Caching.Memory;
using System;

namespace MyWeb.BAL.Cache
{
    public class CacheData : ICacheData
    {
        private readonly IMemoryCache _memoryCache;

        public CacheData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<T>(string key, T obj, TimeSpan time)
        {
            _memoryCache.Set(key, obj, time);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
           _memoryCache.Remove(key);
        }
    }
}
