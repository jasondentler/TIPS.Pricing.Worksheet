using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Ninject.Web.WebApi.FilterBindingSyntax;
using Raven.Client;
using Raven.Client.Document;

namespace TIPS.Pricing.UI.Wireup
{
    public class RavenModule : NinjectModule 
    {
        public override void Load()
        {
            var store = new DocumentStore()
                {
                    ConnectionStringName = "raven"
                }.Initialize();

            Kernel.Bind<IDocumentStore>().ToConstant(store);

            Kernel.Bind<IDocumentSession>()
                  .ToMethod(ctx => ctx.Kernel.Get<IDocumentStore>().OpenSession())
                  .InRequestScope();

            Kernel.BindFilter<RavenMvcFilter>(FilterScope.Global, 0);

            Kernel.BindHttpFilter<RavenWebApiFilter>(System.Web.Http.Filters.FilterScope.Global);
        }
    }
}
