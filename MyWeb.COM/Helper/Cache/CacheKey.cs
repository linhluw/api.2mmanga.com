using System;

namespace MyWeb.COM.Cache
{
    public class CacheKey
    {
        public const string DanhMuc = "DanhMuc";

        public const string News = "News";
    }

    public class CacheTime
    {
        public static TimeSpan Default = TimeSpan.FromDays(1);

        public static TimeSpan Default20minutes = TimeSpan.FromMinutes(20);
    }
}
