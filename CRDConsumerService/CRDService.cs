using ESCaching.MethodRerouteEntity;
using ESFramework.CustomAttributes;
using ESRedisCache;
using IESBusinessContract;
using Interceptors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CRDConsumerService
{
    public class CRDService
    {
        //private readonly ITaskCenterContract taskCenterService = CSInterceptIWindsor.Instance.Resolve<ITaskCenterContract>();
        private static RedisHelper redisHelper = RedisProvider.ESMethod;
        private static Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
        private static readonly object locker = new object();
        private object GetIntance(Type type)
        {
            if (!dictionary.ContainsKey(type))
            {
                lock (locker)
                {
                    if (dictionary.ContainsKey(type))
                    {
                        return dictionary[type];
                    }
                    else
                    {
                        dictionary.Add(type, Activator.CreateInstance(type, true));
                    }
                }
            }
            return dictionary[type];
        }
        public void Start(int group)
        {
            if (group == 0)
                return;
            while (true)
            {
                var entity = redisHelper.PopItemFromList<ReflectionMap>(RedisKeys.ESCRDKey + group);
                if (entity == null)
                {
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    MethodInfo methodInfo = entity.ReflectedType.GetMethod(entity.Name);
                    ParameterInfo[] paramsInfo = methodInfo.GetParameters();
                    object returnValue = methodInfo.Invoke(GetIntance(entity.ReflectedType), entity.Arguments);
                }
            }
        }

    }
}
