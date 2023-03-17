using MyWeb.COM.Cache;

namespace MyWeb.COM.Helper.Cache
{
    public class ManagerCacheString
    {
        public static string ConstructCacheKey(params object[] objs)
        {
            string[] keys = GetCacheItemStrings(objs);

            if (keys == null) return string.Empty;

            return string.Join("_", keys);
        }

        /// <summary>
        /// trungtq: chuyen thang lay ra gia tri default khhi thang key bi null.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static string[] GetCacheItemStrings(object[] arr)
        {
            if (arr == null || arr.Length == 0) return null;

            string[] keys = new string[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                object ob = TypeHelper.GetDefaultValue<object>(arr[i]);

                if (ob is CacheKey)
                {
                    keys[i] = "[" + ob.ToString().ToUpper() + "]";
                }
                else keys[i] = "(" + ob.ToString().ToUpper() + ")";
            }
            return keys;
        }
    }
}
