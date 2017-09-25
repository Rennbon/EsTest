﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace ESMemoryCache
{
    /// <summary>
    /// 缓存执行者
    /// </summary>
    internal sealed class InternalCacher : ICache
    {
        // private static readonly log4net.ILog Logger = LogManager.GetLogger(typeof(InternalCacher));
        private readonly ICollection<ICache> _caches;

        /// <summary>
        /// 初始化一个<see cref="InternalCacher"/>类型的新实例
        /// </summary>
        public InternalCacher(string region)
        {
            _caches = CacheManager.Providers.Where(m => m != null).Select(m => m.GetCache(region)).ToList();
            if (_caches.Count == 0)
            {
                //Logger.Warn("");
            }
        }

        #region Implementation of ICache

        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>获取的数据</returns>
        public object Get(string key)
        {
            object value = null;
            foreach (ICache cache in _caches)
            {
                value = cache.Get(key);
                if (value != null)
                {
                    break;
                }
            }
            return value;
        }

        /// <summary>
        /// 从缓存中获取强类型数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>获取的强类型数据</returns>
        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        /// <summary>
        /// 使用默认配置添加或替换缓存项
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        public void Set(string key, object value)
        {
            foreach (ICache cache in _caches)
            {
                cache.Set(key, value);
            }
        }

        /// <summary>
        /// 添加或替换缓存项并设置绝对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="absoluteExpiration">绝对过期时间，过了这个时间点，缓存即过期</param>
        public void Set(string key, object value, DateTime absoluteExpiration)
        {
            foreach (ICache cach in _caches)
            {
                cach.Set(key, value, absoluteExpiration);
            }
        }

        /// <summary>
        /// 添加或替换缓存项并设置相对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="slidingExpiration">滑动过期时间，在此时间内访问缓存，缓存将继续有效</param>
        public void Set(string key, object value, TimeSpan slidingExpiration)
        {
            foreach (ICache cach in _caches)
            {
                cach.Set(key, value, slidingExpiration);
            }
        }

        /// <summary>
        /// 移除指定键的缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            foreach (ICache cach in _caches)
            {
                cach.Remove(key);
            }
        }

        #endregion
    }
}
