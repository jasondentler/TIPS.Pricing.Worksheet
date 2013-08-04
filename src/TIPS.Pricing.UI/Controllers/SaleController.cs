using System.Collections.Generic;
using System.Web.Http;
using TIPS.Pricing.Data;

namespace TIPS.Pricing.UI.Controllers
{
    public class SaleController : ApiController 
    {
        private readonly SaleIdTypeAheadQuery _saleIdTypeAheadQuery;
        private readonly SaleQuery _saleQuery;

        public SaleController(SaleIdTypeAheadQuery saleIdTypeAheadQuery, SaleQuery saleQuery)
        {
            _saleIdTypeAheadQuery = saleIdTypeAheadQuery;
            _saleQuery = saleQuery;
        }

        /// <summary>
        /// TypeAhead for sale selection
        /// </summary>
        public IEnumerable<SaleSummary> Get(string q)
        {
            return _saleIdTypeAheadQuery.Execute(q);
        }

        public Sale Get(long id)
        {
            var result = _saleQuery.Execute(id);
            return result;
        }

    }
}