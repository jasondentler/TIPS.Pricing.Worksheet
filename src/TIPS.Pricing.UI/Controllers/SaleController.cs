using System.Collections.Generic;
using System.Web.Http;
using TIPS.Pricing.UI.Models;

namespace TIPS.Pricing.UI.Controllers
{
    public class SaleController : ApiController 
    {
        public IEnumerable<SaleSummary> Get(string q)
        {
            yield return new SaleSummary()
            {
                SaleId = 1,
                JobNumber = "12340001",
                CustomerName = "Ward and June Cleaver",
                Address = "555 Cinco Road",
                Community = "Cinco Ranch 55'"
            };

            yield return new SaleSummary()
            {
                SaleId = 2,
                JobNumber = "12340001",
                CustomerName = "Showcase",
                Address = "555 Cinco Road",
                Community = "Cinco Ranch 55'"
            };

            yield return new SaleSummary()
            {
                SaleId = 3,
                JobNumber = "12340002",
                CustomerName = "George and Judy Jetson",
                Address = "556 Cinco Road",
                Community = "Cinco Ranch 55'"
            };

        }

    }
}