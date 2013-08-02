using System.Web.Http.Filters;
using Raven.Client;

namespace TIPS.Pricing.UI.Wireup
{
    public class RavenWebApiFilter : ActionFilterAttribute
    {
        private readonly IDocumentSession _session;

        public RavenWebApiFilter(IDocumentSession session)
        {
            _session = session;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
                _session.SaveChanges();

            _session.Dispose();
        }
    }
}