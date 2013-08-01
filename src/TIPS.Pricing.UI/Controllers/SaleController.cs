using System.Collections.Generic;
using System.Web.Http;
using TIPS.Pricing.Data;

namespace TIPS.Pricing.UI.Controllers
{
    public class SaleController : ApiController 
    {
        private readonly SaleIdTypeAheadQuery _saleIdTypeAheadQuery;

        public SaleController(SaleIdTypeAheadQuery saleIdTypeAheadQuery)
        {
            _saleIdTypeAheadQuery = saleIdTypeAheadQuery;
        }
        
        public IEnumerable<SaleSummary> Get(string q)
        {
            return _saleIdTypeAheadQuery.Execute(q);
        }

    }
}