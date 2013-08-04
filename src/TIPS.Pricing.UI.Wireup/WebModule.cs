using System.Web.Http;
using System.Web.Mvc;
using Ninject.Modules;
using System;
using Ninject;

namespace TIPS.Pricing.UI.Wireup
{

    public class WebModule : NinjectModule
    {

        public override void Load()
        {
            Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => Kernel);


            DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(Kernel));

        }
    }
}