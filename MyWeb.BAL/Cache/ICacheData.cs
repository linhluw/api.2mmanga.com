using System;

namespace MyWeb.BAL.Cache
{
    public interface ICacheData
    {
        void Set<T>(string key, T obj, TimeSpan time);

        T Get<T>(string key);

        void Remove(string key);
    }
}
