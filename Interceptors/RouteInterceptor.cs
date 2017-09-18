using Castle.DynamicProxy;
using ESFramework.CustomAttributes;
using System;
using System.Reflection;

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
               
            }
            else
            {
                invocation.Proceed();
            }


            var parameters = invocation.Method.GetParameters();
            if (parameters.Length > 0)
            {
                var parameter = parameters[0];
                var parameterValue = invocation.GetArgumentValue(0);

                var type = parameter.ParameterType;

                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    //string 判断
                    //var attr = property.GetCustomAttribute(typeof(StringRequiredAttribute), false);
                    //if (attr != null)
                    //{
                    //    var val = property.GetValue(parameterValue) as string;
                    //    if (string.IsNullOrEmpty(val))
                    //    {
                    //        validate = false;
                    //        propertyName = property.Name;
                    //        break;
                    //    }
                    //}

                    ////list 判断
                    //var listAtt = property.GetCustomAttribute(typeof(ListRequiredAttribute), false);
                    //if (listAtt != null)
                    //{
                    //    if (!(property.GetValue(parameterValue) is IList val) || val.Count == 0)
                    //    {
                    //        validate = false;
                    //        propertyName = property.Name;
                    //        break;
                    //    }
                    //}
                }
            }

        }
    }
}
