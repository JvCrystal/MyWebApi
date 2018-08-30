using Microsoft.Extensions.Caching.Memory;
using System;

namespace MyWebApi.Token
{
    public class MemoryCacheHelp
    {
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            object cached;
            return _cache.TryGetValue(key, out cached);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.Get(key);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间），单位为分</param>
        /// <param name="expiressAbsoulte">绝对过期时长，单位为天</param>
        /// <returns></returns>
        public static bool AddMemoryCache(string key, object value, int expiresSliding, int expiressAbsoulte)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddMinutes(expiresSliding);
            DateTime d3 = d1.AddDays(expiressAbsoulte);
            TimeSpan sliding = d2 - d1;
            TimeSpan absoulute = d3 - d1;

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _cache.Set(key, value,
                    new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(sliding)
                    .SetAbsoluteExpiration(absoulute)
                    );

            return Exists(key);
        }
    }
}
