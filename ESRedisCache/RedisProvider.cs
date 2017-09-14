using System;
using System.Collections.Generic;
using System.Text;

namespace ESRedisCache
{
    public class RedisProvider
    {
        private static RedisHelper mdRedisHelper = null;
        /// <summary>
        /// WWW Redis
        /// </summary>
        public static RedisHelper Interface
        {
            get
            {
                if (mdRedisHelper == null)
                {
                    mdRedisHelper = new RedisHelper("127.0.0.1:6379");
                }
                return mdRedisHelper;
            }
        }
    }
}
