using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;

namespace SCBF.Web
{
    public class MvcApplication : AbpWebApplication<TAFWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {

            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config"));

            base.Application_Start(sender, e);

            //            using (var context = new TAFDbContext())
            //            {
            //                new InitialHostDbBuilder(context).Create();
            //                new DefaultTenantCreator(context).Create();
            //                new TenantRoleAndUserBuilder(context, 1).Create();
            //            }
        }
    }
}
