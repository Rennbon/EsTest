using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;

namespace ESMemoryCache
{
    /// <summary>
    /// 运行时内存缓存（单例)
    /// </summary>
    public class RuntimeMemoryCache : CacheBase
    {
        private readonly string _region;
        private static MemoryCache _cache;

        /// <summary>
        /// 初始化一个<see cref="RuntimeMemoryCache"/>类型的新实例
        /// </summary>
        public RuntimeMemoryCache(string region)
        {
            _region = region;
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }
        }

        /// <summary>
        /// 获取 缓存区域名称，可作为缓存键标识，给缓存管理带来便利
        /// </summary>
        public override string Region
        {
            get { return _region; }
        }

        #region Implementation of ICache

        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>获取的数据</returns>
        public override object Get(string key)
        {
            string cacheKey = GetCacheKey(key);
            _cache.TryGetValue(cacheKey, out object val);
            if (val == null)
                return val;
            DictionaryEntry entry = (DictionaryEntry)val;
            return entry.Value;
        }

        /// <summary>
        /// 从缓存中获取强类型数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>获取的强类型数据</returns>
        public override T Get<T>(string key)
        {
            return (T)Get(key);
        }

        /// <summary>
        /// 使用默认配置添加或替换缓存项
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        public override void Set(string key, object value)
        {
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry = new DictionaryEntry(key, value);
            _cache.Set(cacheKey, entry);
        }

        /// <summary>
        /// 添加或替换缓存项并设置绝对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="absoluteExpiration">绝对过期时间，过了这个时间点，缓存即过期</param>
        public override void Set(string key, object value, DateTime absoluteExpiration)
        {
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry = new DictionaryEntry(key, value);
            var result = _cache.Set(cacheKey, entry, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiration
            });
        }

        /// <summary>
        /// 添加或替换缓存项并设置相对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="slidingExpiration">滑动过期时间，在此时间内访问缓存，缓存将继续有效</param>
        public override void Set(string key, object value, TimeSpan slidingExpiration)
        {
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry = new DictionaryEntry(key, value);
            var result = _cache.Set(cacheKey, entry, new MemoryCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            });
        }

        /// <summary>
        /// 移除指定键的缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public override void Remove(string key)
        {
            string cacheKey = GetCacheKey(key);
            _cache.Remove(cacheKey);
        }
        #endregion

        #region 私有方法

        private string GetCacheKey(string key)
        {
            return string.Concat(_region, ":", key, "@", key.GetHashCode());
        }

        #endregion
    }
}
