using System;
using System.Collections.Generic;
using NHibernate;

namespace TIPS.Pricing.Data
{
    public class SelectedOptionsQuery : Query 
    {
        public SelectedOptionsQuery(ISession session) : base(session)
        {
        }

        public IEnumerable<Option> Execute(long saleId)
        {
            throw new NotImplementedException();
        }

    }
}
