using System.Web;
using System.Web.Optimization;

namespace TIPS.Pricing
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib.js").Include(
                "~/js/jquery-{version}.js",
                "~/js/hogan-{version}.js",
                "~/js/bootstrap.js",
                "~/js/typeahead.js"));

            bundles.Add(new StyleBundle("~/bundles/lib.css").Include(
                "~/css/bootstrap.css",
                "~/css/typeahead.css"));
        }
    }
}