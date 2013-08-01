using System.Collections.Generic;
using NHibernate;

namespace TIPS.Pricing.Data
{
    public class SaleIdTypeAheadQuery : Query
    {
        public SaleIdTypeAheadQuery(ISession session) : base(session)
        {
        }

        public IEnumerable<SaleSummary> Execute(string keywords)
        {
            return Session
                .GetNamedQuery("SaleIdTypeAhead")
                .SetParameter("Keywords", keywords)
                .List<SaleSummary>();
        }

    }
}
