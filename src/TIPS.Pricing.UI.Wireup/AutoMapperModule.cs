using Ninject.Modules;

namespace TIPS.Pricing.UI.Wireup
{
    public class AutoMapperModule : NinjectModule 
    {
        public override void Load()
        {
            AutoMapperMaps.Setup();
        }
    }
}
