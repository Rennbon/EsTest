using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ESFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interceptors
{
    public class CSInterceptIWindsor
    {
        private readonly IWindsorContainer container;

        private static readonly Lazy<CSInterceptIWindsor> Lazy = new Lazy<CSInterceptIWindsor>(() => new CSInterceptIWindsor());

        public static IWindsorContainer Instance => Lazy.Value.container;

        private CSInterceptIWindsor()
        {
            container = new WindsorContainer();

            container.Register(Classes.FromAssemblyNamed("EsBusiness")
                     .BasedOn<IContract>().WithService.FromInterface());

        }
    }
}
