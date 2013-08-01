using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using TIPS.Pricing.Data;

namespace TIPS.Pricing.UI.Wireup
{
    public class NHibernateModule:NinjectModule 
    {
        public override void Load()
        {
            var cfg = new Configuration()
                .DataBaseIntegration(db =>
                    {
                        db.ConnectionStringName = "sql";
                        db.Dialect<MsSql2005Dialect>();
                        db.BatchSize = 500;
                    })
                .AddAssembly(typeof (SaleIdTypeAheadQuery).Assembly);

            Kernel.Bind<ISessionFactory>()
                  .ToConstant(cfg.BuildSessionFactory());

            Kernel.Bind<ISession>()
                  .ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession())
                  .InRequestScope();
        }
    }
}
