using System.Web.Http;
using System.Web.Mvc;
using Ninject.Modules;
using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

namespace TIPS.Pricing.UI
{

    public class WebModule : NinjectModule
    {

        public override void Load()
        {
            Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => Kernel);


            DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(Kernel));

            //// Install our Ninject-based IDependencyResolver into the Web API config
            var resolver = new NinjectDependencyResolver(Kernel);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}