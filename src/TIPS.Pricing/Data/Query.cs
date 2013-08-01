using NHibernate;

namespace TIPS.Pricing.Data
{
    public abstract class Query
    {
        protected readonly ISession Session;

        protected Query(ISession session)
        {
            Session = session;
        }

    }
}