using System;

namespace MyWeb.COM.Cache
{
    public class CacheKey
    {
        public const string CacheAll = "ALL";

        public const string CacheKeyId = "KEYID";
    }

    public class CacheTime
    {
        public static TimeSpan Default = TimeSpan.FromDays(1);

        public static TimeSpan Default30Minutes = TimeSpan.FromMinutes(30);

        public static TimeSpan Default1Hours = TimeSpan.FromHours(1);
    }
}
