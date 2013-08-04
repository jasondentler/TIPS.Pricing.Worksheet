using System.Web.Http;
using Ninject.Modules;

namespace TIPS.Pricing.UI.Wireup
{
    public class WebApiModule : NinjectModule 
    {
        public override void Load()
        {
            var cfg = GlobalConfiguration.Configuration;

            //// Install our Ninject-based IDependencyResolver into the Web API config
            var resolver = new NinjectDependencyResolver(Kernel);
            cfg.DependencyResolver = resolver;

            // Because who uses this anymore?
            cfg.Formatters.Remove(cfg.Formatters.XmlFormatter);

            // Because we can do better
            cfg.Formatters.Remove(cfg.Formatters.JsonFormatter);

            // Use Newtonsoft Json.Net serializer instead
            cfg.Formatters.Add(new JsonNetFormatter());
        }
    }
}
