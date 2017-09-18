using Castle.DynamicProxy;
using ESFramework.CustomAttributes;
using IESBusinessContract;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using ESCaching.MethodRerouteEntity;
using ESRedisCache;
using ESFramework;

namespace Interceptors
{
    public class RouteInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            var reroute = false;
            RerouteGroupType group = RerouteGroupType.Defualt;
            var rerouteAb = invocation.MethodInvocationTarget.GetCustomAttribute<RerouteAttribute>();
            if (rerouteAb != null)
            {
                if (rerouteAb.Group != RerouteGroupType.Defualt)
                {
                    reroute = true;
                }
                else
                {
                    group = rerouteAb.Group;
                }
            }
            if (reroute)
            {
                //string name = invocation.Method.Name;
                //object[] arguments = invocation.Arguments;
                //Type reflectedType = invocation.MethodInvocationTarget.ReflectedType;
                //ReflectionMap reflectionMap = new ReflectionMap(name, arguments, reflectedType);
                //RedisProvider.ESMethod.AddItemToList<ReflectionMap>(RedisKeys.ESCRDKey, reflectionMap);

                //反射调用方法（后续服务逻辑，千万别打开注释）
                //object obj = Activator.CreateInstance(reflectedType, true);
                //MethodInfo methodInfo = reflectedType.GetMethod(name);
                //ParameterInfo[] paramsInfo = methodInfo.GetParameters();
                //object returnValue = methodInfo.Invoke(obj, arguments);
                invocation.ReturnValue = new ReturnResult(ResultCode.Success);
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
