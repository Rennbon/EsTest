using Castle.DynamicProxy;
using System;

namespace Interceptors
{
    public class RouteInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var a = invocation;
        }
    }
}
