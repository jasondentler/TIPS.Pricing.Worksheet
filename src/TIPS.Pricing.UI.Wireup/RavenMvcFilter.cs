using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Raven.Client;

namespace TIPS.Pricing.UI.Wireup
{
    public class RavenMvcFilter : IActionFilter
    {
        private readonly IDocumentSession _session;

        public RavenMvcFilter(IDocumentSession session)
        {
            _session = session;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction && filterContext.Exception == null)
            {
                _session.SaveChanges();
            }
            _session.Dispose();
        }
    }
}
