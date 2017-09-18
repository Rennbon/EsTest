﻿using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Text;
using ESFramework;

namespace Interceptors
{
    public class IOCContainer
    {
        private readonly IWindsorContainer container;

        private static readonly Lazy<IOCContainer> Lazy = new Lazy<IOCContainer>(() => new IOCContainer());

        public static IWindsorContainer Instance => Lazy.Value.container;

        private IOCContainer()
        {
            container = new WindsorContainer();
            container.Register(Component.For<IInterceptor>().ImplementedBy<RouteInterceptor>());

            container.Register(Classes.FromAssemblyNamed("EsBusiness")
                     .BasedOn<IContract>().WithService.FromInterface());

            //container.Register(Classes.FromAssemblyNamed("IESBusinessContract")
            //                .Pick()
            //                .If(t => t.Name.EndsWith("Contract"))
            //                .WithService.DefaultInterfaces());
        }
    }
}