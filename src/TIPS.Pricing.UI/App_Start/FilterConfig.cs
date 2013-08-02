using System.Web.Mvc;
using TIPS.Pricing.UI.Wireup;

namespace TIPS.Pricing.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}